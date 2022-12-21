using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // A reference to the pause menu canvas
    public Canvas pauseMenuCanvas;

    // A reference to the resume button
    public Button resumeButton;

    // A reference to the exit button
    public Button exitButton;

    void Start()
    {
        // Set the pause menu canvas to inactive
        pauseMenuCanvas.gameObject.SetActive(false);

        // Add a listener to the resume button's OnClick event
        resumeButton.onClick.AddListener(ResumeGame);

        // Add a listener to the exit button's OnClick event
        exitButton.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        // If the player presses the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the pause menu
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        // If the pause menu canvas is active
        if (pauseMenuCanvas.gameObject.activeSelf)
        {
            // Set the pause menu canvas to inactive
            pauseMenuCanvas.gameObject.SetActive(false);

            // Unpause the game
            Time.timeScale = 1;
        }
        else
        {
            // Set the pause menu canvas to active
            pauseMenuCanvas.gameObject.SetActive(true);

            // Pause the game
            Time.timeScale = 0;
        }
    }

    void ResumeGame()
    {
        // Set the pause menu canvas to inactive
        pauseMenuCanvas.gameObject.SetActive(false);

        // Unpause the game
        Time.timeScale = 1;
    }

    void ExitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
