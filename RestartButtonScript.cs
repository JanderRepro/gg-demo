using UnityEngine;
using System.Collections;

public class RestartButtonScript : ButtonScript {

	// Use this for initialization
	public override void OnClick () {
		base.OnClick ();
		Application.LoadLevel (Application.loadedLevel);
	}
}
