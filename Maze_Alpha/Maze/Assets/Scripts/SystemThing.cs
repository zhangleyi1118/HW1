using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemThing : MonoBehaviour
{
    public Canvas Esc_ground;
    public Canvas Start_ground;
    // Start is called before the first frame update
    void Start()
    {
        Esc_ground.gameObject.SetActive(false);
        Start_ground.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible =true;
            Esc_ground.gameObject.SetActive(true);
       }
    }
}
