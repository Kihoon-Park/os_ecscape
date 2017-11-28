using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public enum GameMode
{
    FPS_MODE,
    UI_MODE,
};

public enum InventoryCondition
{
    ON,
    OFF,
};


public class GameManager : MonoBehaviour
{
    GameMode gameMode = GameMode.FPS_MODE;
    InventoryCondition inventoryCondition = InventoryCondition.OFF;
    public GameObject uiCanvas;
    public GameObject inventoryPanel;
    public Vector3 inventoryPos;
    Vector3 inventoryOrgPos;
    public FirstPersonController fpsController;

    // Use this for initialization
    void Start()
    {
        inventoryOrgPos = inventoryPanel.transform.position;
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            switch (inventoryCondition)
            {
                case InventoryCondition.OFF:
                    ChangeCondition(InventoryCondition.ON);
                    break;
                case InventoryCondition.ON:
                    ChangeCondition(InventoryCondition.OFF);
                    break;
                default:
                    break;
            }
        }       
    }


    void ChangeMode(GameMode mode)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        switch (mode)
        {
            case GameMode.FPS_MODE:
                uiCanvas.SetActive(false);
                fpsController.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case GameMode.UI_MODE:
                uiCanvas.SetActive(true);
                fpsController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            default:
                break;
        }

        gameMode = mode;
    }

    void ChangeCondition(InventoryCondition condition)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        switch (condition)
        {
            case InventoryCondition.ON:
                inventoryPanel.transform.position = inventoryOrgPos + inventoryPos;
                fpsController.enabled = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case InventoryCondition.OFF:
                inventoryPanel.transform.position = inventoryOrgPos;
                fpsController.enabled = true;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            default:
                break;
        }

        inventoryCondition = condition;
    }
}