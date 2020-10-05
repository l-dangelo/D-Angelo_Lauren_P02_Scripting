using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    [SerializeField] GameObject _pauseMenu;

    int _currentScore;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isActive = _pauseMenu.activeSelf;
            _pauseMenu.SetActive(!isActive);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
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
    }

    public void quitGameFromPause()
    {
        Application.Quit();
    }
}
