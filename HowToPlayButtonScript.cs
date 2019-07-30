using UnityEngine;
using System.Collections;

public class HowToPlayButtonScript : ButtonScript {

	public GameObject htppanel;

	// Use this for initialization
	public override void Awake () {
		base.Awake ();
		htppanel.SetActive (false);
	}
	
	public override void OnClick(){
		base.OnClick ();
		htppanel.SetActive (true);
	}
}
