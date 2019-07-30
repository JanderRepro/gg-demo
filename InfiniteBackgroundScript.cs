using UnityEngine;
using System.Collections;

public class InfiniteBackgroundScript : MonoBehaviour {

	public Vector3 moveto;
	public GameObject parentobj;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			parentobj.transform.position = parentobj.transform.position + moveto;
		}
	}
}
