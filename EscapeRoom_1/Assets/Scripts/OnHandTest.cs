using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHandTest : MonoBehaviour {
    public Transform obj1;
    public Transform obj2;
	public Transform torc;
    bool onHand = false;

    void Start () 
    {

    }

    void Update ()
    {

        if(Input.GetKeyDown(KeyCode.R))
        {
            if(Vector3.Distance(transform.position, obj1.transform.position) <= 5)
            {
                if(onHand)
                {
                    obj1.transform.parent = null;
                }
                else
                {
                    obj1.transform.parent = transform;
                    obj1.transform.position = transform.position + transform.forward * 5f;
                }

                onHand = !onHand;
            }
            else if(Vector3.Distance(transform.position, obj2.transform.position) <= 5)
            {
                if(onHand)
                {
                    obj2.transform.parent = null;
                }
                else
                {
                    obj2.transform.parent = transform;
                    obj2.transform.position = transform.position + transform.forward * 5f;
                }

                onHand = !onHand;
            }
			else if(Vector3.Distance(transform.position, torc.transform.position) <= 5)
			{
				if(onHand)
				{
					torc.transform.parent = null;
				}
				else
				{
					torc.transform.parent = transform;
					torc.transform.position = transform.position + transform.forward * 5f;
				}

				onHand = !onHand;
			}
        }
    }
}