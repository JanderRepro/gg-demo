using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneStartScript : MonoBehaviour {

	public GameObject title;
	public GameObject instruction;
	public GameObject highscore;
	public LevelInformationScript source;

	void Awake () {
		source = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
		title.GetComponent<Text>().text = source.title;
		instruction.GetComponent<Text>().text = source.instructions;
		if(source.scoreistimed == false)
			highscore.GetComponent<Text> ().text = "High Score\n" + PlayerPrefs.GetFloat ("highscore"+Application.loadedLevelName);
		else
			highscore.GetComponent<Text> ().text = "Best Time\n" + PlayerPrefs.GetFloat ("highscore"+Application.loadedLevelName  );
	}
}