using UnityEngine;
using System.Collections;

public class DoNotTouchScript : MonoBehaviour {

	public AudioClip thissound;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
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
