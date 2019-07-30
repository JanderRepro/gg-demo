using UnityEngine;
using System.Collections;

public class PlayerThunkScript : MonoBehaviour {

	public AudioClip thunknoise;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other){
		audio.PlayOneShot (thunknoise, rigidbody.velocity.magnitude / 1f);
	}
}
