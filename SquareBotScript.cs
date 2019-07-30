using UnityEngine;
using System.Collections;

public class SquareBotScript : MonoBehaviour {

	public Vector3 dir;
	public float speed;
	public int hp;
	public GameObject explosion;
	public GameObject exploserousgraphic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (dir * Time.deltaTime * speed);
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "trigger") {
			if(dir == Vector3.up){
				dir = Vector3.left;
			}
			else if(dir == Vector3.left){
				dir = Vector3.down;
			}
			else if(dir == Vector3.down){
				dir = Vector3.right;
			}
			else if(dir == Vector3.right){
				dir = Vector3.up;
			}
		}
	}

	void OnCollisionEnter(Collision other){
		hp--;
		if (hp == 0) {
			Destroy(gameObject);
			GameObject kaboom = Instantiate (explosion, transform.position, transform.rotation) as GameObject;
			GameObject seekaboom = Instantiate (exploserousgraphic, transform.position, transform.rotation) as GameObject;
			kaboom.GetComponent<AudioSource> ().volume = 0.5f;
			GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ().Goal--;
		}
	}

}
