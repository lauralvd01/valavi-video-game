using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Nivel : MonoBehaviour
{
    public int nivel;
    public GameObject hintPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartNivelButton() {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.Lvlrst);
        switch (nivel) {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel1");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel2");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel3");
                break;
            default:
                UnityEngine.SceneManagement.SceneManager.LoadScene("HomeScene");
                break;
        }
    }

    public void GoToMenuButton() {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.ITEM);
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomeScene");
    }

    public void GetHintButton() {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.ITEM);
        hintPanel.SetActive(true);
    }

    public void HideHintButton() {
        hintPanel.SetActive(false);
    }
}
