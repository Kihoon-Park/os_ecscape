using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeDelay : MonoBehaviour {
	private float delayTime = 3;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (delayTime);

		Application.LoadLevel("StartingMenu");
	}
}
