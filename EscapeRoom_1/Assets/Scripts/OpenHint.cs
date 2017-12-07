using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHint : MonoBehaviour {

	public GameObject passwordHint;
	private Flash flash;

	void Start()
	{
		flash = GameObject.Find ("/torch/flashlight").GetComponent<Flash> ();
	}

	void Update()
	{
		if (flash.isLightOn == false) 
		{
			passwordHint.SetActive (false);
		}
	}

	void OnTriggerStay(Collider collision) 
	{
		if (collision.gameObject.CompareTag ("hint1")) 
		{
			Debug.Log ("crash");
			passwordHint.SetActive (true);
		} 
		else 
		{
			Debug.Log ("no");
			passwordHint.SetActive (false);
		}
	}

}
