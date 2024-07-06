using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Button : MonoBehaviour
{
    public Canvas Esc_ground;
    public Canvas Start_ground;
    public GameObject Player;

    public void ExitClick()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void ContinueClick()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ReturnClick()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Esc_ground.gameObject.SetActive(false);
        Start_ground.gameObject.SetActive(true);
    }
    public void StartGameClick()
    {
        Start_ground.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Read()
    {

    }

    public void Continue_Start_Click() {
        ContinueClick();
        Esc_ground.gameObject.SetActive(false);
        Start_ground.gameObject.SetActive(false);

    }
    public void Continue_Esc_Click() {
        ContinueClick();
        Esc_ground.gameObject.SetActive(false);
        Start_ground.gameObject.SetActive(false);
    }
}
