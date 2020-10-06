using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView = null;
    [SerializeField] Text _currentHealthTextView = null;
    [SerializeField] GameObject _player = null;
    [SerializeField] GameObject _pauseMenu = null;

    int _currentScore;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapeToggle();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }
    }

    public void escapeToggle()
    {
        bool isActive = _pauseMenu.activeSelf;
        if (!isActive)
        {
            _pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else if (isActive)
        {
            _pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }        
    }

    public void ExitLevel()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");

        if(_currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New High Score: " + _currentScore);
        }
        SceneManager.LoadScene("MainMenu");
    }
    
    public void IncreaseScore(int scoreIncrease)
    {
        _currentScore += scoreIncrease;

        _currentScoreTextView.text = " Score: " + _currentScore.ToString();
    }

    public void resume()
    {
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void quitGameFromPause()
    {
        Application.Quit();
    }

    public void displayHealth()
    {
        float playHealth = _player.GetComponent<PlayerHealth>().getCurrentHealth();
        _currentHealthTextView.text = "Health: " + playHealth.ToString();
    }
}
