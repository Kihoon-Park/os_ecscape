using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour 
{

	public Light flight;
	public Collider ff;
	public bool on;
	private OnHand onHand;
	// Use this for initialization
	void Start () 
	{
		onHand = GameObject.Find ("/FPSController/FirstPersonCharacter").GetComponent<OnHand> ();
		on = false;
		flight.enabled = false;
		ff.enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if ((Input.GetKeyDown (KeyCode.F))&&(onHand.isOnHand)) 
		{
			if (on == true) 
			{
				flight.enabled = false;
				on = false;
				ff.enabled = false;
			} 
			else if (on == false) 
			{
				flight.enabled = true;
				on = true;
				ff.enabled = true;
			}
		}
	}
}
