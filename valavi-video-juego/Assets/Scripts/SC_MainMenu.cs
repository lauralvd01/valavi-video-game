using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        AudioManager.Instance.PlaySFX(AudioManager.Instance.ITEM);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel1");
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.ITEM);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Lvlrst);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Lvlrst);
    }
}