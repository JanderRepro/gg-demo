using UnityEngine;
using System.Collections;

public class IgnoreBallScript : MonoBehaviour {

	public Collider plasticball;
	public AudioClip bloop;
	public AudioSource audio;

	// Use this for initialization
	void Awake () {
		plasticball = GameObject.Find ("Plastic Ball").GetComponent<Collider> ();
		Physics.IgnoreCollision (plasticball.GetComponent<Collider> (), GetComponent<Collider> ());
	}

	void FixedUpdate(){
		Physics.IgnoreCollision (plasticball, this.collider);
	}

	void OnCollisionEnter(Collision other){
		audio.PlayOneShot (bloop, 1f);
	}
}
