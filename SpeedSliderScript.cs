using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedSliderScript : MonoBehaviour {

	public PlayerForce pfscript;
	public Text slidetext;
	public Slider slider;
	public int sval;

	void Awake () {
		pfscript = GameObject.Find ("Plastic Ball").GetComponent<PlayerForce> ();
		if (PlayerPrefs.GetInt ("playerforce") >= 1 && PlayerPrefs.GetInt ("playerforce") <= 6) {
			slider.value = PlayerPrefs.GetInt ("playerforce");
		}

		this.gameObject.SetActive (false);
	}

	public void Change () {
		slidetext.text = slider.value.ToString();
		sval = (int) slider.value;
	}

	void OnDisable(){
		pfscript.force = slider.value * 100;
		PlayerPrefs.SetInt ("playerforce", sval);
	}
}
