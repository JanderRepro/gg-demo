using UnityEngine;
using System.Collections;

public class WaterFloatScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider other) {
		other.rigidbody.AddForce (transform.forward * 100f * Time.deltaTime, ForceMode.Acceleration);
	}
}
