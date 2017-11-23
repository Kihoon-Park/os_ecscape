using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Doorlock : MonoBehaviour
{
    public GameObject passwordPanel;
    public Text passwordText;

    // Use this for initialization
    void Start()
    {
        passwordText.text = "";
    }

    public void Inputnum(int num)
    {
        if (num == 1)
            passwordText.text += 1;
        if (num == 2)
            passwordText.text += 2;
        if (num == 3)
            passwordText.text += 3;
        if (num == 4)
            passwordText.text += 4;
        if (num == 5)
            passwordText.text += 5;
        if (num == 6)
            passwordText.text += 6;
        if (num == 7)
            passwordText.text += 7;
        if (num == 8)
            passwordText.text += 8;
        if (num == 9)
            passwordText.text += 9;
        if (num == 0)
            passwordText.text += 0;
    }

    public void Clearnum()
    {
        passwordText.text = "";
    }

    public void Gameclear()
    {
        if (passwordText.text == "4321")
            SceneManager.LoadScene(4);
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
