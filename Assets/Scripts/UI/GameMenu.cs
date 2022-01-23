using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject playerSelectMenu;
    public GameObject characterMenu;

    public IntVar p1Score;
    public IntVar p2Score;

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
}
