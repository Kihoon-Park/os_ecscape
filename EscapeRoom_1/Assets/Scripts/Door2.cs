using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    bool bOpen2 = false;
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
            float end = bOpen2 ? 90 : 0;
            Vector3 rot = new Vector3(0, end, 0);
            iTween.RotateTo(gameObject, rot, 1);

            bOpen2 = !bOpen2;
        }
    }
}