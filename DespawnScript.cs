using UnityEngine;
using System.Collections;

public class DespawnScript : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		if (other.tag != "trigger") {
			Destroy (other.transform.root.gameObject);
		}
	}
}