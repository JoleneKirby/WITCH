using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    [HideInInspector] public bool GamePaused;

    public GameObject PauseMenu;

    public GameObject Crosshair;

    private void Start()
    {
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused == false)
            {
                PauseMenu.SetActive(true);
                Crosshair.SetActive(false);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                GamePaused = true;
            }
            else
            {
                PauseMenu.SetActive(false);
                Crosshair.SetActive(true);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                GamePaused = false;
            }
        }
    }
}

