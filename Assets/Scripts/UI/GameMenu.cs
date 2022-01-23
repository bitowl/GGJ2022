using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject playerSelectMenu;
    public GameObject characterMenu;

    public IntVar p1Score;
    public IntVar p2Score;
    public MenuState menuState;

    void Start()
    {
        // Load menu state that was requested by previous screen
        switch (menuState.state)
        {
            case MenuState.State.Main:
                ShowMainMenu();
                break;
            case MenuState.State.PlayerSelection:
                ShowPlayerSelectMenu();
                break;
            case MenuState.State.CharacterSelection:
                ShowCharacterMenu();
                break;
        }
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        playerSelectMenu.SetActive(false);
        characterMenu.SetActive(false);
    }

    public void ShowPlayerSelectMenu()
    {
        mainMenu.SetActive(false);
        playerSelectMenu.SetActive(true);
        characterMenu.SetActive(false);
    }

    public void ShowCharacterMenu()
    {
        mainMenu.SetActive(false);
        playerSelectMenu.SetActive(false);
        characterMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
        p1Score.value = 0;
        p2Score.value = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
