using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishButtonScript : ButtonScript {

	public bool removeonawake = true;

	public void OnClick () {
		base.OnClick ();
		if (name != "Finish Button") {
			//Debug.Log (this.transform.GetChild(0).GetComponent<Text>().text);
			Application.LoadLevel (name);
		} else {
			if(PlayerPrefs.GetInt ("levelscomplete") < Application.loadedLevel){
				PlayerPrefs.SetInt ("levelscomplete", Application.loadedLevel);
			}
			Application.LoadLevel (Application.loadedLevel + 1);
			}
	}

	void Awake(){
		base.Awake ();
		if (name != "Finish Button" && removeonawake == true) {
			this.gameObject.SetActive (false);
		}
	}

	void Start(){
		if (name == "Finish Button") {
			this.gameObject.SetActive (false);
		}
	}
}
