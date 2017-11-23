using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Password : MonoBehaviour
{
    public Text myText1;
    // Use this for initialization
    void Start()
    {
        myText1.text = "";
    }

    public void Inputnum(int num)
    {
        if (num == 1)
            myText1.text += 1;
        if (num == 2)
            myText1.text += 2;
        if (num == 3)
            myText1.text += 3;
        if (num == 4)
            myText1.text += 4;
        if (num == 5)
            myText1.text += 5;
        if (num == 6)
            myText1.text += 6;
        if (num == 7)
            myText1.text += 7;
        if (num == 8)
            myText1.text += 8;
        if (num == 9)
            myText1.text += 9;
        if (num == 0)
            myText1.text += 0;
    }

    public void clearnum()
    {
        myText1.text = "";
    }

    public void gameclear()
    {
        if (myText1.text == "4321")
            SceneManager.LoadScene(4);
    }

    // Update is called once per frame
    void Update()
    {

    }
}