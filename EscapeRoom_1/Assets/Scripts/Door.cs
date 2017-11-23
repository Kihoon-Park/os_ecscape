using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool bOpen = false;
    public float speed;
    public GameObject door;
    public GameObject key1;
    public GameObject keyHole;
    private OnHandTest onHandTest;
    // Use this for initialization


    void Start()
    {
        onHandTest = GameObject.Find("/FPSController/FirstPersonCharacter").GetComponent<OnHandTest>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Debug.Log(onHandTest.onHand);
        // Debug.Log(Input.GetMouseButtonDown(0));
        // Debug.Log(Vector3.Distance(keyHole.transform.position, key1.transform.position) <= 1);
        if ((Input.GetMouseButtonDown(0))&&(onHandTest.onHand == false)&&(Vector3.Distance(keyHole.transform.position, key1.transform.position) <= 1))
        {

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                onHandTest.obj.SetActive(false);
                onHandTest.obj.transform.parent = null;
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