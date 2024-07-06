using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemThing : MonoBehaviour
{
    public Canvas ui_ground;
    // Start is called before the first frame update
    void Start()
    {
        ui_ground.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible =true;
            ui_ground.gameObject.SetActive(true);
       }
    }
}
