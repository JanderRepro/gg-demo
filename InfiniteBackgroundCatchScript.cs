using UnityEngine;
using System.Collections;

public class InfiniteBackgroundCatchScript : MonoBehaviour {

	public Vector3 moveto;
	public GameObject parentobj;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerExit (Collider other){
		if (other.tag == "Player") {
			parentobj.transform.position = other.transform.position + moveto;
		}
	}
}
