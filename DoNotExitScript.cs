using UnityEngine;
using System.Collections;

public class DoNotExitScript : MonoBehaviour {

	public GameObject player;
	public LevelInformationScript script;
	
	void Awake () {
		script = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
	}

	void FixedUpdate(){
		if (Mathf.Abs (transform.localPosition.x) > 1f)
			Disable ();
		if (Mathf.Abs (transform.localPosition.y) > 1f)
			Disable ();
	}

	public void Disable(){
		rigidbody.useGravity = false;
		var rb = player.gameObject.GetComponent<Rigidbody>();
		rb.useGravity = true;
		var pscript = player.gameObject.GetComponent<PlayerForce>();
		pscript.enabled = false;
	}
}
