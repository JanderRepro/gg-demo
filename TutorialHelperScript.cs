using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialHelperScript : MonoBehaviour {

	public GameObject phoneobj;
	public Rigidbody phonerb;
	public Transform phonereset;
	public int step;
	public Text instructtext;
	public PauseButtonScript pozscript;
	public GameObject pozbut;
	public GameObject rezbut;

	// Use this for initialization
	void Awake () {
		phonereset = phoneobj.transform;
		instructtext.fontStyle = FontStyle.BoldAndItalic;
		instructtext.color = Color.red;
	}
	
	void OnTriggerStay(Collider other) {
		if (other.tag == "Player" && Time.timeScale == 1) {
			pozscript.OnClick();
			pozbut.SetActive(false);
			rezbut.AddComponent<PulseScript>();
			step++;
			if(step > 150){
				phoneobj.SetActive (true);
				step = 0;
			}
			if(step > 106 && phoneobj.activeSelf){
				phonerb.angularVelocity = Vector3.zero;
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			phonerb.angularVelocity = Vector3.zero;
			phoneobj.transform.rotation = Quaternion.identity;
			phoneobj.SetActive (false);
			step = 0;
		}
	}
}
