using UnityEngine;
using System.Collections;

public class SpaceSpawnScript : MonoBehaviour {

	public GameObject[] junk;
	public GameObject foodattach;
	public Vector3 spawnvalues;
	public int junkcount;
	public int junkmax;
	public float spawnwait;
	public float startwait;
	public float wavewait;
	public Transform tl;
	public Transform tr;
	public Transform bl;
	public Transform br;
	public Vector3 spawnposition;
	public PlayerForce gs;
	//public Mesh starmesh;
	//public Material starmaterial;
	
	// Use this for initialization
	void Start () {
		gs = GameObject.Find ("Plastic Ball").GetComponent<PlayerForce> ();
		StartCoroutine (SpawnWaves ());
	}

	void Update (){
		//Graphics.DrawMesh (starmesh, Vector3.zero, Quaternion.identity, starmaterial, 0);
	}
	
	IEnumerator SpawnWaves (){
		while (true) {
			for (int i = 0; i < junkcount; i++){
				if(junkcount < junkmax){
					int spawnselect = Random.Range (0, 3);
					if (gs.direction.y > 0 && Mathf.Abs (gs.direction.y) > Mathf.Abs (gs.direction.x)){
						spawnposition = new Vector3 (Random.Range (tl.position.x, tr.position.x), tl.position.y, 0f); //spawn from top
						Debug.Log ("Top");
					}
					else if (gs.direction.y < 0 && Mathf.Abs (gs.direction.y) > Mathf.Abs (gs.direction.x)){
						spawnposition = new Vector3 (Random.Range (bl.position.x, br.position.x), bl.position.y, 0f); //spawn from bottom
						Debug.Log ("Bottom");
					}
					else if (gs.direction.x < 0 && Mathf.Abs (gs.direction.x) > Mathf.Abs (gs.direction.y)){
						spawnposition = new Vector3 (bl.position.x, Random.Range(tl.position.y, bl.position.y), 0f); //spawn from left
						Debug.Log ("Left");
					}
					else if (gs.direction.x > 0 && Mathf.Abs (gs.direction.x) > Mathf.Abs (gs.direction.y)){
						spawnposition = new Vector3 (br.position.x, Random.Range(tr.position.y, br.position.y), 0f); //spawn from rightt
						Debug.Log ("Right");
					}
					else{
						spawnposition = new Vector3 (Random.Range (tl.position.x, tr.position.x), tl.position.y, 0f); //spawn from top
						Debug.Log ("Blerghk");
					}
					Quaternion spawnrotation = Random.rotation;
					spawnrotation.x = 0;
					spawnrotation.y = 0;
					int junkselect = Random.Range (0, junk.Length);
					GameObject newjunk = Instantiate (junk[junkselect], spawnposition, spawnrotation) as GameObject;
					newjunk.AddComponent<SpaceJunkControlScript>();

					//strap food pellet to new junk, to its child, if applicable
					if(junkselect > 3){
						//spawnrotation.x = 20;
						GameObject newfood = Instantiate (foodattach, spawnposition, spawnrotation) as GameObject;
						var foodscript = newfood.AddComponent<AttachedFoodScript>();
						/*if(newjunk.transform.childCount > 0){
							foodscript.strapped = newjunk.transform.GetChild(0);
						} else */foodscript.strapped = newjunk.transform;
						var fooderscript = newjunk.AddComponent<AttacherFoodScript>();
						fooderscript.fscript = foodscript;
					}
					junkcount++;
				}
				yield return new WaitForSeconds (spawnwait);
			}
			//yield return new WaitForSeconds (wavewait);
		}
	}
}