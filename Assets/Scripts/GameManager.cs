using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public enum WorldColour { White, Red, Green, Blue};

    public WorldColour currentColour;
    public GameObject pauseCanvas;
    private bool isPaused = false;
    public bool enableDayNightCycle = true;
    public bool isDay;
    public float dayDuration;
    public float nightDuration;
    public GameObject HUDCanvas;
    public GameObject SwitchCircle;
    public GameObject startObject;
    public GameObject finishObject;
    public List<GameObject> checkpoints;
    public GameObject currentRespawnPoint;
    public bool Victory;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Text timerText;
    float timer = 0.0f;
    public Text livesText;
    int seconds;
    void Start()
    {
        currentRespawnPoint = startObject;
        Cursor.lockState = CursorLockMode.Locked;
        PauseGame(false);
        //DontDestroyOnLoad(pauseCanvas);
        //DontDestroyOnLoad(this);
        //SwitchCircle.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().Lives = 5;

    }

    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);
        timerText.text = "Timer: " + seconds.ToString();
    }

    public void PauseGame(bool _pause)
    {
        if (_pause)
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseCanvas.SetActive(isPaused);
            Cursor.lockState = CursorLockMode.None;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().cameraLock = true;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseCanvas.SetActive(isPaused);
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().cameraLock = false;
        }
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    /*******************************
     * Day / Night Cycle Functions *
     * *****************************/

    public void ChangeColour(WorldColour newColour)
    {
        int numberOfLights = GameObject.FindGameObjectsWithTag("ColourLight").Length;
        int numberOfEnemies = GameObject.FindGameObjectsWithTag("ColourEnemy").Length;
        if (currentColour != newColour && newColour == WorldColour.White)
        {
            currentColour = WorldColour.White;
            skinnedMeshRenderer.material.color = Color.white;
            for (int i = 0; i < numberOfLights; i++)
            {
                GameObject.FindGameObjectsWithTag("ColourLight")[i].GetComponent<Light>().color = Color.white;
            }
        }
        else if (currentColour != newColour && newColour == WorldColour.Red)
        {
            currentColour = WorldColour.Red;
            skinnedMeshRenderer.material.color = Color.red;
            for (int i = 0; i < numberOfLights; i++)
            {
                GameObject.FindGameObjectsWithTag("ColourLight")[i].GetComponent<Light>().color = Color.red;
            }
        }
        else if (currentColour != newColour && newColour == WorldColour.Green)
        {
            currentColour = WorldColour.Green;
            skinnedMeshRenderer.material.color = Color.green;
            for (int i = 0; i < numberOfLights; i++)
            {
                GameObject.FindGameObjectsWithTag("ColourLight")[i].GetComponent<Light>().color = Color.green;
            }
        }
        else if (currentColour != newColour && newColour == WorldColour.Blue)
        {
            currentColour = WorldColour.Blue;
            skinnedMeshRenderer.material.color = Color.blue;
            for (int i = 0; i < numberOfLights; i++)
            {
                GameObject.FindGameObjectsWithTag("ColourLight")[i].GetComponent<Light>().color = Color.blue;
            }
        }
    }

    public void ToggleSwitchCircle(bool switchCircleToggle)
    {
        if (switchCircleToggle)
        {
            SwitchCircle.SetActive(false);
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().cameraLock = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            SwitchCircle.SetActive(true);
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().cameraLock = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void SetLivesText(int i)
    {
        livesText.text = "Lives: " + i.ToString();
    }
    public void EndGame()
    {
        if (GameObject.FindWithTag("VictoryCheck") != null)
        {
            GameObject.FindWithTag("VictoryCheck").GetComponent<VictoryCheck>().Score = 1000 - seconds;
        }
        SceneManager.LoadScene("GameEnd");
        Cursor.lockState = CursorLockMode.None;
    }
}
