using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenAdjustSliderScript : MonoBehaviour {
	
	public RectTransform hiscore;
	public RectTransform curscore;
	public RectTransform title;
	public RectTransform instructions;
	public RectTransform marijanovic;
	public GameObject adjustcanvas;
	public Slider slidey;
	public Camera cam;
	public float UIscale;

	// Use this for initialization
	void Awake () {
		if (PlayerPrefs.GetFloat ("screenwidth") != 0) {
			slidey.value = PlayerPrefs.GetFloat ("screenwidth");
			cam.orthographicSize = 5;
			adjustcanvas.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		//pinch control
		if (Input.touchCount == 2) {
			Touch touchzero = Input.GetTouch (0);
			Touch touchone = Input.GetTouch (1);

			Vector2 touchzeroprev = touchzero.position - touchzero.deltaPosition;
			Vector2 touchoneprev = touchone.position - touchone.deltaPosition;

			float prevtouchdeltamag = (touchzeroprev - touchoneprev).magnitude;
			float touchdeltamag = (touchzero.position - touchone.position).magnitude;

			float deltamagdif = prevtouchdeltamag - touchdeltamag;

			slidey.value += deltamagdif / 2f;
		}

		UIscale = 0.004140786f * cam.orthographicSize;
		adjustcanvas.transform.localScale = new Vector3 (UIscale, UIscale, UIscale);
		hiscore.offsetMin = new Vector2(slidey.value, 116);
		curscore.offsetMax = new Vector2 (-slidey.value, -124);
		instructions.offsetMax = new Vector2 (-slidey.value - 5, -10);
		title.offsetMax = new Vector2 (-slidey.value - 15, 0.5f);
		marijanovic.sizeDelta = new Vector2 (90 - slidey.value, 95);
	}
}
