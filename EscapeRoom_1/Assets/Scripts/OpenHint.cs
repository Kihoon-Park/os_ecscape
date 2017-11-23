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
			//Debug.Log ("test");
			passwordHint.SetActive (true);
		} 
		else 
		{
			passwordHint.SetActive (false);
		}
	}

}
