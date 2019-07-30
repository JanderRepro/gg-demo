using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButtonScript : ButtonScript {

	/*public GameObject head;
	public GameObject larm;
	public GameObject rarm;
	public GameObject lleg;
	public GameObject rleg;*/

	public GameObject panel;
	public GameObject poz;
	public GameObject exitbutton;
	public bool clickable = false;
	public bool clicked = false;
	public float delay;

	void Update(){
		//if (Time.unscaledTime > delay + 2 && clicked == false) {
			GetComponent<Button> ().interactable = true;
			clickable = true;
		//}
		/*if (Input.anyKey && clickable == true) {
			GetComponent<Button> ().interactable = false;
			StartCoroutine(shrink(panel.transform));
			clickable = false;
			clicked = true;
		}*/
	}

	// Use this for initialization
	void Start () {
		delay = Time.unscaledTime;
		Time.timeScale = 0f;
		GetComponent<Button> ().interactable = false;
	}

	void OnGUI(){
	}
	
	public override void OnClick(){
		base.OnClick ();
		GetComponent<Button> ().interactable = false;
		StartCoroutine(shrink(panel.transform));
		clickable = false;
		clicked = true;
	}

	public IEnumerator shrink(Transform size){
		int step = 0;
		Transform baset = size;
		while(step < 45){
			size.Rotate(Vector3.up*2);
			step++;
			yield return null;
		}
		Time.timeScale = 1f;
		size.rotation = Quaternion.identity;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		poz.SetActive (true);
		panel.SetActive (false);
		exitbutton.SetActive (false);
		Destroy (this.gameObject);
	}
}
