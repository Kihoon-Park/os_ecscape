using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_c : MonoBehaviour {

	public GameObject Building;

	public void BuildingSetActive()
	{
		Building.SetActive (!Building.active);
	}
}
