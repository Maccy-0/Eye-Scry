using UnityEngine;
using UnityEngine.Rendering;

public class StartGame : MonoBehaviour
{
    public GameObject mainScene;
    public GameObject background;
    public GameObject backgroundTwo;
    public GameObject menu;
    public GameObject onBoradMen;
    public GameObject volume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void UnlockGame()
    {
        mainScene.SetActive(true);
        background.SetActive(false);
        menu.SetActive(false);
    }

    public void FullScreen()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
        
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void FinishOnboarding()
    {
        backgroundTwo.SetActive(true);
        background.SetActive(true);
        menu.SetActive(true);
        onBoradMen.SetActive(false);
    }

    public void OnboardMe()
    {
        onBoradMen.SetActive(false);
        volume.SetActive(true);
    }

}
