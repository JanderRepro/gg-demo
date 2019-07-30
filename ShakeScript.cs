using UnityEngine;
using System.Collections;

public class ShakeScript : MonoBehaviour {

	public bool left = true;

	void Start (){
		//transform.Translate (Vector3.down * 2f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (left == true) {
			transform.Translate (Vector3.up * 6f * Time.deltaTime);
			left = false;
		} else {
			transform.Translate (Vector3.down * 6f * Time.deltaTime);
			left = true;
		}
	}
}
