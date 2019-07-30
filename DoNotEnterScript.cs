using UnityEngine;
using System.Collections;

public class DoNotEnterScript : MonoBehaviour {

	//public GameObject player;
	public AudioClip thissound;
	public AudioSource audio;

	// Use this for initialization
	void Awake () {
		//player = GameObject.FindWithTag("Player");
	}
	
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			if (thissound != null){
				audio.PlayOneShot(thissound, 1f);
			}
			var rb = other.gameObject.GetComponent<Rigidbody>();
			rb.useGravity = true;
			var script = other.gameObject.GetComponent<PlayerForce>();
			script.enabled = false;
		}
	}
}
