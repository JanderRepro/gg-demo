using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZoomButtonScript : ButtonScript {

	public LevelInformationScript script;
	public float zoomto;
	public Vector3 zoomlocation;
	public float speed;
	public float current = 10;
	public GameObject camobj;
	public GameObject startpanel;
	public Camera camcam;
	public bool zoomed = false;
	public Image icon;
	public bool stayoff = false;
	public Sprite inicon;
	public Sprite outicon;

	// Use this for initialization
	void Awake () {
		base.Awake ();
		camobj = GameObject.FindGameObjectWithTag ("MainCamera");
		camcam = camobj.GetComponent<Camera> ();
		script = GameObject.Find ("EventSystem").GetComponent<LevelInformationScript> ();
		//zoomto = script.fullzoom;
		zoomlocation = camobj.transform.position;
		startpanel = GameObject.Find ("Scene Start Panel");
	}

	void Start (){
		zoomto = script.fullzoom;
		this.gameObject.SetActive (false);
		if (stayoff == true) {
			//Destroy(this.gameObject);
		}
	}

	public void OnClick(){
		base.OnClick ();
		if(zoomed == false){
			ZoomOut();
		}
		else ZoomIn ();
	}

	public void ZoomOut(){
		startpanel.SetActive (false);
		current = zoomto;
		zoomed = true;
		icon.sprite = inicon;
	}

	public void ZoomIn(){
		startpanel.SetActive (true);
		current = 10;
		zoomed = false;
		icon.sprite = outicon;
	}

	void OnDisable(){
		ZoomIn ();
	}

	public void LateUpdate(){
		camcam.orthographicSize = Mathf.Lerp (camcam.orthographicSize, current, speed);
		if (zoomed == true) {
			camobj.transform.position = Vector3.Slerp (zoomlocation, Vector3.zero, speed);
		}
	}
}
