using UnityEngine;
using System.Collections;

public class EarthRotateDetector : MonoBehaviour {
	
	public float zoomto;
	public GameObject camobj;
	public CamControl camcam;
	public LevelInformationScript script;
	public float ident;


	// Use this for initialization
	void Awake () {
		camobj = GameObject.FindGameObjectWithTag ("MainCamera");
		camcam = camobj.GetComponent<CamControl> ();
		script = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "trigger") {
			camcam.orthozoom = zoomto;
			if(script.Goal == ident){
				script.Goal--;
			}
			else script.Goal++;
		}
	}
}
