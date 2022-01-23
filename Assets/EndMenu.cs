using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public MenuState menuState;

    public void NewGame()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
    }

    public void ChangeCharacters()
    {
        menuState.state = MenuState.State.CharacterSelection;
        SceneManager.LoadScene("GameMenu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        menuState.state = MenuState.State.Main;
        SceneManager.LoadScene("GameMenu");
        Time.timeScale = 1;
    }
}
