﻿using UnityEngine;
using System.Collections;

public class TapToDeactivateScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.anyKey)
		this.gameObject.SetActive (false);
	}
}
