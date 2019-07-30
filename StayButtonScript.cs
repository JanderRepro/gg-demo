using UnityEngine;
using System.Collections;

public class StayButtonScript : MonoBehaviour {

	public GameObject brotherbutton;
	public GameObject otherbutton;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
		brotherbutton.SetActive (true);
	}
	
	// Update is called once per frame
	public void OnClick () {
		Time.timeScale = 1f;
		otherbutton.SetActive (true);
		transform.parent.gameObject.SetActive (false);
	}
}
