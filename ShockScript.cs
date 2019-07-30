using UnityEngine;
using System.Collections;

public class ShockScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			ShakeScript ss = other.gameObject.AddComponent<ShakeScript>();
		}
	}
}
