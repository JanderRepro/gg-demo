using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

	public Vector3 pivot;
	public GameObject target;

	void Awaken(){
		rigidbody.centerOfMass = pivot;
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "trigger") {
			target.GetComponent<TriggerScript>().trigger();
			transform.Rotate(Vector3.right * Time.deltaTime);
		}
	}

	void Update(){
		rigidbody.AddTorque(transform.forward * 0.5f);
	}
}
