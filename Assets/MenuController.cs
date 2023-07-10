using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public GameObject menu;
    public ThirdPersonCamera cameraController;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        }

        if (!menu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //cameraController.enableToggle();
            cameraController.enabled = true;

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //cameraController.enableToggle();
            cameraController.enabled = false;
        }
	}

    public void quitGame()
    {
        Application.Quit();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
