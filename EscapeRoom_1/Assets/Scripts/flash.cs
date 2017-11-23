using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

	public Light flight;
	public Collider ff;
	public bool on;
	private OnHandTest onHandTest;
	// Use this for initialization
	void Start () {
		onHandTest = GameObject.Find ("/FPSController/FirstPersonCharacter").GetComponent<OnHandTest> ();
		on = false;
		flight.enabled = false;
		ff.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.F))&&(onHandTest.onHand)) {
			if (on == true) {
				flight.enabled = false;
				on = false;
				ff.enabled = false;
			} else if (on == false) {
				flight.enabled = true;
				on = true;
				ff.enabled = true;
			}
		}
	}
}
