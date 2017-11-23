using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHand : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject torc;
    public GameObject obj;
    public GameObject fps;
    private Inventory inv;
    public bool isOnHand = false;

    void Start ()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if((Vector3.Distance(transform.position, obj1.transform.position) <= 3.5) && (obj1.activeSelf))
            {
                if(isOnHand)
                {
                    obj1.transform.parent = null;
                }
                else
                {
                    obj1.transform.parent = transform;
                    obj1.transform.position = transform.position + transform.forward * 3f;
                    obj = obj1;
                }
                isOnHand = !isOnHand;
            }
            else if((Vector3.Distance(transform.position, obj2.transform.position) <= 3.5) && (obj.activeSelf))
            {
                if(isOnHand)
                {
                    obj2.transform.parent = null;
                }
                else
                {
                    obj2.transform.parent = transform;
                    obj2.transform.position = transform.position + transform.forward * 3f;
                    obj = obj2;
                }
                isOnHand = !isOnHand;
            }
            else if((Vector3.Distance(transform.position, torc.transform.position) <= 3.5) && (torc.activeSelf))
            {
                if(isOnHand)
                {
                    torc.transform.parent = null;
                }
                else
                {
                    torc.transform.parent = transform;
                    torc.transform.position = transform.position + transform.forward * 1f;
                    obj = torc;
                }
                isOnHand = !isOnHand;
            }
        }
        if(Input.GetKeyDown(KeyCode.T)&&isOnHand)
        {
            obj.SetActive(false);
            if(obj.tag == "Key1")
            {
                inv.AddItem(0);
            }
            if(obj.tag == "Key2")
            {
                inv.AddItem(1);
            }
            if(obj.tag == "Torc")
            {
                inv.AddItem(2);
            }
            obj.transform.parent = null;
            isOnHand = !isOnHand;
        }
    }
}