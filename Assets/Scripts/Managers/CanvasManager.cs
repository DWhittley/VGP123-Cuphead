using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [Header("Button")]
    public Button startButton;
    public Button settingsButton;
    public Button quitButton;
    public Button returnToMenuButton;
    public Button returnToGameButton;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    [Header("Text")]
    public Text livesText;
    public Text volSliderText;

    [Header("Slider")]
    public Slider volSlider;

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    void ShowMainMenu()
    {
        if (SceneManager.GetActiveScene().name == "Level")
        {
            SceneManager.LoadScene("Title");
        }
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    void OnSliderValueChanged(float value)
    {
        if (volSliderText)
            volSliderText.text = value.ToString();
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void GameOver()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    void UpdateLifeText(int value)
    {
        livesText.text = value.ToString();
        
        if (value == 0)
            GameOver();
    }


    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
            startButton.onClick.AddListener(StartGame);

        if (settingsButton)
            settingsButton.onClick.AddListener(ShowSettingsMenu);

        if (quitButton)
            quitButton.onClick.AddListener(QuitGame);

        if (returnToMenuButton)
            returnToMenuButton.onClick.AddListener(ShowMainMenu);

        if (returnToGameButton)
            returnToGameButton.onClick.AddListener(ResumeGame);

        if (volSlider)
            volSlider.onValueChanged.AddListener(OnSliderValueChanged);

        if (livesText)
            GameManager.instance.onLifeValueChanged.AddListener(UpdateLifeText);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pauseMenu)
            {
                pauseMenu.SetActive(true);
                PauseGame();
            }
            if (pauseMenu)
            {
                pauseMenu.SetActive(false);
                ResumeGame();
            }
                

            //pauseMenu.SetActive(!pauseMenu.activeSelf);

            //if (pauseMenu.activeSelf)
            //{
            //    PauseGame();
            //}
            //if (pauseMenu.activeSelf)
            //{
            //    ResumeGame();
            //}
        }
        
    }
}
