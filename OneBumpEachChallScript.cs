using UnityEngine;
using System.Collections;

public class OneBumpEachChallScript : MonoBehaviour {

	public bool onebump = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {

		}
	}
}
