using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool bOpen = false;
    public float speed;
    public GameObject door;
    // Use this for initialization

    void Start()
    {

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
                    float end = bOpen ? 90 : 0;
                    Vector3 rot = new Vector3(-90, 0, -end);
                    iTween.RotateTo(door, rot, speed);

                    bOpen = !bOpen;
                }
            }
        }
    }
}