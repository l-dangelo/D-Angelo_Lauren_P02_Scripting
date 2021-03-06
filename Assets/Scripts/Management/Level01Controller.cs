﻿using System.Collections;
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

    [Header("Scripts to Turn Off")]
    [SerializeField] FireWeapon _fireWeapon = null;
    [SerializeField] weaponFire _weaponFire = null;

    int _currentScore;
    bool _pauseMenuActive = false;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapeToggle();
        }
    }

    public void escapeToggle()
    {
        if (!_pauseMenuActive)
        {
            _pauseMenu.SetActive(true);
            _pauseMenuActive = true;
            _fireWeapon.enabled = false;
            _weaponFire.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _player.GetComponent<PlayerMovement>().SetMove(false);
        }
        else if (_pauseMenuActive)
        {
            _pauseMenu.SetActive(false);
            _pauseMenuActive = false;
            _fireWeapon.enabled = true;
            _weaponFire.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            _player.GetComponent<PlayerMovement>().SetMove(true);
        }     
    }

    public bool GetPauseMenuActivity()
    {
        return _pauseMenuActive;
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

    public void displayHealth()
    {
        float playHealth = _player.GetComponent<PlayerHealth>().getCurrentHealth();
        _currentHealthTextView.text = "Health: " + playHealth.ToString();
    }
}