using UnityEngine;
using System.Collections;

public class PoisonScoreScript : PoisonScript {

	public LevelInformationScript script;

	// Use this for initialization
	public override void Awake () {
		base.Awake ();
		script = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
	}

	public override void spit() {
		base.spit ();
		script.Goal -= 1;
	}
}
