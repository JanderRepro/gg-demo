using UnityEngine;
using System.Collections;

public class VacuumScript : MonoBehaviour {

	public float force = 1f;
	//public Vector3 explosionpoint = Vector3.forward;

	// Use this for initialization
	void Start () {
		Debug.Log (transform.forward);
	
	}

	void OnTriggerStay (Collider other) {
		//other.rigidbody.AddExplosionForce (force * Time.deltaTime, explosionpoint, 2f, 3f);
		other.transform.root.gameObject.rigidbody.AddForce (transform.forward * force * Time.deltaTime);
		other.transform.root.gameObject.rigidbody.AddTorque(Vector3.forward * force * Time.deltaTime);
	}
}