using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("SplitscreenTest");
    }

    public void QuitGame()
    {
        Debug.Log("PLS KILL GAME!");
        Application.Quit();
    }
}
