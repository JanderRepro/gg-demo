using UnityEngine;
using System.Collections;

public class CarnivalCansChallScript : MonoBehaviour {

	public LevelInformationScript infoscript;
	public GameObject leftpit;
	public GameObject rightpit;
	public ItemDetectScript leftscript;
	public ItemDetectScript rightscript;

	// Use this for initialization
	void Awake () {
		infoscript = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
		leftscript = leftpit.GetComponent<ItemDetectScript> ();
		rightscript = rightpit.GetComponent<ItemDetectScript> ();
	}

	public void Check(){
		if (leftscript.hasitem == false || rightscript.hasitem == false) {
			PlayerPrefs.SetInt ("onesided"+Application.loadedLevelName, 1);
		}
	}

	void OnEnable () {
		LevelInformationScript.OnComplete += Check;
	}

	void OnDisable (){
		LevelInformationScript.OnComplete -= Check;
	}
}
