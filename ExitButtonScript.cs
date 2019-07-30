using UnityEngine;
using System.Collections;

public class ExitButtonScript : MonoBehaviour {

	public void OnClick(){
		Application.LoadLevel ("TitleScreen");
	}
}
