using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHint : MonoBehaviour {

	public GameObject col2;
	private Flash fla;

	void Start()
	{
		fla = GameObject.Find ("/torch/flashlight").GetComponent<Flash> ();
	}

	void Update()
	{
		if (fla.on == false) {
			col2.SetActive (false);
		}
	}

	void OnTriggerStay(Collider collision) {
		if (collision.gameObject.CompareTag ("hint1")) {
			Debug.Log ("test");
			col2.SetActive (true);
		} else {
			col2.SetActive (false);
		}
	}

}
