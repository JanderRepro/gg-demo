using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelInformationScript : MonoBehaviour {

	public GameObject finish;
	public GameObject finishchild;

	public string title;
	public string instructions;
	public string nextlevel;
	public float goal = 1; //number associated with level goal, when it reaches zero, the level is complete
	public bool scroll; //whether or not the camera scrolls with player movement
	public float fullzoom; //The necessary size for the camera to zoom out on pause
	public Vector3 zoomoutpos;
	public bool scoreistimed = true; //Should be true for puzzles, false for Infinity
	public GameObject scorecounter;
	public GameObject highscorecounter;
	public RectTransform marijanovic;
	public float timestart;
	public float currenttime;
	public float targettime;
	public AudioClip levelmusic;

	public delegate void LevelComplete();
	public static event LevelComplete OnComplete;

	public float Goal {
		set{
			goal = value;
			if(scoreistimed == false){
				scorecounter.GetComponent<Text> ().text = "Score\n" + Mathf.Abs (goal);
			}
			if(goal == 0){
				finish.SetActive(true);
				finishchild.SetActive(true);
				if(OnComplete != null){
					OnComplete();
				}
				if(scoreistimed == true){
					if(currenttime < PlayerPrefs.GetFloat ("highscore"+Application.loadedLevelName) || PlayerPrefs.GetFloat ("highscore"+Application.loadedLevelName) == 0){
						PlayerPrefs.SetFloat ("highscore"+Application.loadedLevelName, Mathf.Abs (currenttime));
						highscorecounter.GetComponent<Text> ().text = "Best Time\n" + Mathf.Abs (currenttime);
						if(currenttime < targettime){
							PlayerPrefs.SetInt ("timetrophy"+Application.loadedLevelName, 1);
						}
					}
				}
			}
		}
		get{
			return goal;
		}
	}

	void Awake (){
		fullzoom = GameObject.Find ("Main Camera").GetComponent<Camera> ().orthographicSize;
		finish = GameObject.Find ("Finish Panel");
		finishchild = finish.transform.GetChild (0).gameObject;
		finish.SetActive (false);
		scorecounter = GameObject.Find ("CurrentScoreUI");
		highscorecounter = GameObject.Find ("HighScoreUI");
		marijanovic = GameObject.Find ("Doctor").GetComponent<RectTransform> ();
		if (scoreistimed == true) {
			timestart = Time.time;
		}
		scorecounter.GetComponent<RectTransform>().offsetMax = new Vector2(-PlayerPrefs.GetFloat ("screenwidth"), -124);
		highscorecounter.GetComponent<RectTransform> ().offsetMin = new Vector2 (PlayerPrefs.GetFloat ("screenwidth"), 116);
		marijanovic.sizeDelta = new Vector2 (90 - PlayerPrefs.GetFloat ("screenwidth"), 95);
	}

	void Update (){
		if (scoreistimed == true) {
			if(Goal > 0){
				currenttime = Time.time - timestart;
			}
			scorecounter.GetComponent<Text> ().text = "Time\n" + System.Math.Round (currenttime,2);
		}
	}

	public void HighScoreFunc(){
		if (scoreistimed == true) {
			Goal++; //increase score to prevent success after death
		} else {
			if(Mathf.Abs (goal) > PlayerPrefs.GetFloat ("highscore"+Application.loadedLevelName)){
				PlayerPrefs.SetFloat("highscore"+Application.loadedLevelName, Mathf.Abs (goal));
				highscorecounter.GetComponent<Text> ().text = "Best\n" + Mathf.Abs (goal);
			}
		}
	}

	void OnEnable(){
		PlayerForce.OnDeath += HighScoreFunc;
	}

	void OnDisable(){
		PlayerForce.OnDeath -= HighScoreFunc;
	}
}
