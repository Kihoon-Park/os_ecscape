using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool bOpen = false;
    public float speed = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float end = bOpen ? 90 : 0;
            Vector3 rot = new Vector3(-90, 0, -end);
            iTween.RotateTo(gameObject, rot, 1);

            bOpen = !bOpen;
        }
    }
}