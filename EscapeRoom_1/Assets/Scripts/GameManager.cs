using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public enum GameMode
{
    FPS_MODE,
    UI_MODE,
};

public class GameManager : MonoBehaviour
{
    GameMode gameMode = GameMode.FPS_MODE;
    public GameObject uiCanvas;
    public FirstPersonController fpsController;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (gameMode)
            {
                case GameMode.FPS_MODE:
                    ChangeMode(GameMode.UI_MODE);
                    break;
                case GameMode.UI_MODE:
                    ChangeMode(GameMode.FPS_MODE);
                    break;
                default:
                    break;
            }
        }
    }


    void ChangeMode(GameMode mode)
    {
        switch (mode)
        {
            case GameMode.FPS_MODE:
                uiCanvas.SetActive(false);
                fpsController.enabled = true;
                break;
            case GameMode.UI_MODE:
                uiCanvas.SetActive(true);
                fpsController.enabled = false;
                break;
            default:
                break;
        }

        gameMode = mode;
    }
}
