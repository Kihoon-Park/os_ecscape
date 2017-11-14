using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorlock : MonoBehaviour {
    public GameObject passwordPanel;



    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform == transform)
                {
                    Debug.Log(hit.transform.gameObject.name);
                    passwordPanel.SetActive(true);
                }
            }
        }
    }
}
