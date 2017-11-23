using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour 
{

	public Light flashLight;
	public Collider lightCollider;
	public bool isLightOn;
	private OnHand onHand;
	// Use this for initialization
	void Start () 
	{
		onHand = GameObject.Find ("/FPSController/FirstPersonCharacter").GetComponent<OnHand> ();
		isLightOn = false;
		flashLight.enabled = false;
		lightCollider.enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if ((Input.GetKeyDown (KeyCode.F))&&(onHand.isOnHand)) 
		{
			if (isLightOn == true) 
			{
				flashLight.enabled = false;
				isLightOn = false;
				lightCollider.enabled = false;
			} 
			else if (isLightOn == false) 
			{
				flashLight.enabled = true;
				isLightOn = true;
				lightCollider.enabled = true;
			}
		}
	}
}
