using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHandTest : MonoBehaviour {
    public GameObject obj1;
    public GameObject obj2;
    public GameObject torc;
    public GameObject obj;
    private Inventory inv;
    public bool onHand = false;

    void Start () 
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
             if(obj1 != null)
             {
                if(Vector3.Distance(transform.position, obj1.transform.position) <= 3.5)
                {
                    if(onHand)
                    {
                        obj1.transform.parent = null;
                    }
                    else
                    {
                        obj1.transform.parent = transform;
                        obj1.transform.position = transform.position + transform.forward * 3f;
                        obj = obj1;
                    }

                    onHand = !onHand;
                }
            }
            if(obj2 != null)
            {
                if(Vector3.Distance(transform.position, obj2.transform.position) <= 3.5)
                {
                    if(onHand)
                    {
                        obj2.transform.parent = null;
                    }
                    else
                    {
                        obj2.transform.parent = transform;
                        obj2.transform.position = transform.position + transform.forward * 3f;
                        obj = obj2;
                    }

                    onHand = !onHand;
                }
            }
            if(torc != null)
            {
                if(Vector3.Distance(transform.position, torc.transform.position) <= 3.5)
                {
                    if(onHand)
                    {
                        torc.transform.parent = null;
                    }
                    else
                    {
                        torc.transform.parent = transform;
                        torc.transform.position = transform.position + transform.forward * 1f;
                        obj = torc;
                    }

                    onHand = !onHand;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.T)&&onHand)
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
            onHand = !onHand;
        }
    }
}