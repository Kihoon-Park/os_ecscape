using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHandTest : MonoBehaviour {
   public Transform obj;
   bool onHand = false;
   // Use this for initialization
   void Start () {
      
   }
   
   // Update is called once per frame
   void Update () {
      if(Input.GetMouseButton(0))
      {
         if(onHand)
         {
            obj.transform.parent = null;
         }
         else
         {
            obj.transform.parent = transform;
            obj.transform.position = transform.position + transform.forward * 6f;
         }

         onHand = !onHand;
      }
   }
}