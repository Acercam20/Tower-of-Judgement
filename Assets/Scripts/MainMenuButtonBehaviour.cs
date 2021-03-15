using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartGameButtonPressed()
    {
        SceneManager.LoadScene("ToJ Level1");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnOptionsButtonPressed()
    {
        SceneManager.LoadScene("Options");
    }

    public void OnHTPButtonPressed()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void OnExitGameButtonPressed()
    {
        Application.Quit();
    }

    public void OnCreditsButtonPressed()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("ToJ Main Menu");
    }

    public void OnResumeButtonPressed()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().PauseGame(false);
    }

    public void OnPauseButtonPressed()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().PauseGame(true);
    }
}
