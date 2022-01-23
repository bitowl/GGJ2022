using UnityEngine;

public class GameMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject playerSelectMenu;
    public GameObject characterMenu;

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
}
