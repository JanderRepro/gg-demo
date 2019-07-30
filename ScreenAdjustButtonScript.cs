using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenAdjustButtonScript : MonoBehaviour {

	public Camera cam;
	public GameObject canvas;
	public Slider slidey;
	public GameObject otherbuttons;

	// Use this for initialization
	void OnEnable () {
		otherbuttons.SetActive (false);
	}

	void OnDisable (){
		otherbuttons.SetActive (true);
	}

	public void OnClick(){
		if (canvas.activeSelf) {
			PlayerPrefs.SetFloat ("screenwidth", slidey.value);
			cam.orthographicSize = 5;
			canvas.SetActive (false);
		} else {
			canvas.SetActive(true);
			cam.orthographicSize = 10;
		}
	}
}
