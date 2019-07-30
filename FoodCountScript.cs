using UnityEngine;
using System.Collections;

public class FoodCountScript : MonoBehaviour {

	public StomachScript script;
	public float expiration;

	// Use this for initialization
	void Awake () {
		script = GameObject.Find ("EventSystem").GetComponent<StomachScript> ();
		script.foodcount++;
		expiration = Time.time + 10f;
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Player") {
			expiration = Time.time + 20f;
		}
	}

	public void OnDestroy(){
		script.foodcount--;
	}

	void Update(){
		if (Time.time > expiration) {
			Destroy(this.gameObject);
		}
	}
}
