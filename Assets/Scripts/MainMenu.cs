using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void PlayApp()
    {
        SceneManager.LoadScene(0);

    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Cikis yapildi..");
    }

    public void AppMenu()
    {
        SceneManager.LoadScene(1);
    }

}
