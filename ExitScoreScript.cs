using UnityEngine;
using System.Collections;

public class ExitScoreScript : MonoBehaviour {

	public GameObject targetitem;
	public LevelInformationScript gcscript;

	// Use this for initialization
	void Start () {
		gcscript = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "trigger") {
			gcscript.goal--;
		}
	}
}
