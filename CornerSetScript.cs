using UnityEngine;
using System.Collections;

public class CornerSetScript : MonoBehaviour {

	public Transform horizborder;
	public Transform vertiborder;
	public Vector3 tempvec = new Vector3 (1f, 1f, 1f);

	// Use this for initialization
	void Start () {
		//Scale
		tempvec.x = horizborder.localScale.y * 2.5f;
		tempvec.y = horizborder.localScale.y * 2.5f;
		transform.localScale = tempvec;

		//Position
		tempvec.z = -1f;
		//tempvec.x = vertiborder.localPosition.x - 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
