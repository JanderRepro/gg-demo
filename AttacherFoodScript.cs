using UnityEngine;
using System.Collections;

public class AttacherFoodScript : MonoBehaviour {

	public AttachedFoodScript fscript;

	// Use this for initialization
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Player") {
			fscript.enabled = false;
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			fscript.enabled = false;
		}
	}
}
