using UnityEngine;
using System.Collections;

public class PoisonDetectScript : MonoBehaviour {

	public int gasses;
	public bool gas;
	public SphereCollider colly;

	// Use this for initialization
	void Awake () {
		gasses = 0;
		gas = false;
	}

	void FixedUpdate (){
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "gascloud") {
			gasses++;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "gascloud") {
			gasses--;
		}
	}
}