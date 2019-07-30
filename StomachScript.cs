using UnityEngine;
using System.Collections;

public class StomachScript : MonoBehaviour {

	public GameObject foods;
	public Vector3 spawnvalues;
	public int foodcount;
	public float spawnwait;
	public float startwait;
	public float wavewait;
	public AudioClip fizzle;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves (){
		while (true) {
			for (int i = 0; i < foodcount; i++){
				Vector3 spawnposition = new Vector3 (Random.Range (-spawnvalues.x, spawnvalues.x), spawnvalues.y, spawnvalues.z);
				Quaternion spawnrotation = Quaternion.identity;
				GameObject newfood = Instantiate (foods, spawnposition, spawnrotation) as GameObject;
				var foodscript = newfood.GetComponent<HazardaphobeScript>().canscore = true;
				var foodscript2 = newfood.GetComponent<HazardaphobeScript>().thissound = fizzle;
				yield return new WaitForSeconds (spawnwait * foodcount * 0.1f);
			}
			//yield return new WaitForSeconds (wavewait);
		}
	}
}
