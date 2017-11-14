using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour {

	public Light flight;
	public bool on = true;
	// Use this for initialization
	void Start () {
		on = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			if (on == true) {
				flight.enabled = false;
				on = false;
			} else if (on == false) {
				flight.enabled = true;
				on = true;
			}
		}
	}
}
