using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneAvantMenu : MonoBehaviour
{
    void Start()
    {

    }

    public void changescene(string scn)
    {
        SceneManager.LoadScene(scn, LoadSceneMode.Single);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Menu");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}