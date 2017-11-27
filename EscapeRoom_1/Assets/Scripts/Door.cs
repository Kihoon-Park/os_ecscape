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
    private OnHand onHand;
    // Use this for initialization


    void Start()
    {
        onHand = GameObject.Find("/FPSController/FirstPersonCharacter").GetComponent<OnHand>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Debug.Log(onHand.isOnHand);
        //Debug.Log(Input.GetMouseButtonDown(0));
        //Debug.Log(Vector3.Distance(keyHole.transform.position, key1.transform.position) <= 1);
        if ((Input.GetMouseButtonDown(0))&&(onHand.isOnHand == false)&&(Vector3.Distance(keyHole.transform.position, key1.transform.position) <= 1))
        {
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform == transform)
                {
                    onHand.obj.SetActive(false);
                    onHand.obj.transform.parent = null;
                    float end = bOpen ? 90 : 0;
                    Vector3 rot = new Vector3(-90, 0, -end);
                    iTween.RotateTo(door, rot, speed);

                    bOpen = !bOpen;
                }
            }
        }
    }
}