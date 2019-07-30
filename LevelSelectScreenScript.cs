using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectScreenScript : MonoBehaviour {

	public RectTransform menulayout;
	public GameObject slidetext;

	// Use this for initialization
	void Start () {

		if (Debug.isDebugBuild) {
			PlayerPrefs.SetInt ("levelscomplete", 32); //Use this if number of finished levels needs debugging.
		}
		if (Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.OSXWebPlayer) { //script for demo
			if(PlayerPrefs.GetInt ("levelscomplete") > 11){
				PlayerPrefs.SetInt ("levelscomplete", 11);
			}
		}

		for (int i = 1; i <= PlayerPrefs.GetInt ("levelscomplete"); i++) {
			this.gameObject.transform.GetChild (i).gameObject.SetActive (true);
		}
		int numrows = PlayerPrefs.GetInt ("levelscomplete") / 3 + 1;
		menulayout.sizeDelta = new Vector2 (300, numrows * 85);
		slidetext = GameObject.Find ("Slidescreentext");
		if (numrows < 5) {
			slidetext.SetActive(false);
		}
	}
}
