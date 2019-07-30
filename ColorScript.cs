using UnityEngine;
using System.Collections;

public class ColorScript : MonoBehaviour {

	public Color colorin;

	void Awake(){
		renderer.material.color = colorin;
	}

	public Color Colorin {
		set{
			colorin = value;
			renderer.material.color = colorin;
		}
		get{
			return colorin;
		}
	}
}
