using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _startingSong = null;
    [SerializeField] Text _highScoreTextView = null;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();

        if(_startingSong != null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }
    }

    public void resetData()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
