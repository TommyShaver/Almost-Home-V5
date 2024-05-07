using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManger { get; private set; }

    public ParticleSystem _explosion;

    //During Game -------------------------------------------------------------
    public UnityEvent _laserHitingRocksData;
    public UnityEvent _laserHittingRockSFX;
    public UnityEvent _startOfGameComms;
    public UnityEvent _inGameTimeEvent1;
    public UnityEvent _inGameTimeEvent2;
    public UnityEvent _inGameTimeEvent3;
    public UnityEvent _inGameTimeEvent4;
    public UnityEvent _WarningSFXLights;
    public UnityEvent _endOfTimeEventsFinalBoss;
    public UnityEvent _scoreSFXGo;

    //End of Game Events ------------------------------------------------------
    public UnityEvent _eogStartShipEngings;
    public UnityEvent _eogLerpForward;
    public UnityEvent _eogStartMusic;
    public UnityEvent _eogMissionComplete;
    public UnityEvent _eogScoreScreen;
    public UnityEvent _eogPlayAgain;
    public UnityEvent _eogCommsGo;

    //Basic Info --------------------------------------------------------------
    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _endscoreText;
    private int _score;


    //GameCheck
    public UnityEvent _storyModeTrue;

    //Game Logic --------------------------------------------------------------
    private void Awake()
    {
        if (_gameManger != null && _gameManger != this)
        {
            Destroy(this);
        }
        else
        {
            _gameManger = this;
        }
        _storyModeTrue.Invoke();
    }

    private void Start()
    {
        StartCoroutine(GameTimer(300));
        // Hides the cursor...
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = _score + " :Score";
        _endscoreText.text = "Score: " + _score;
        _scoreSFXGo.Invoke();
    }

    public void EndOfGameTimerAndLogic()
    {
        StartCoroutine(EndGameTimer(35));
        Cursor.visible = true;
    }




    // Astroid Game Lgoic ----------------------------------------------------
    public void AstroidDestroyed(Asteroid asteroid)
    {
        this._explosion.transform.position = asteroid.transform.position;
        this._explosion.Play();
        _laserHitingRocksData.Invoke();
        _laserHittingRockSFX.Invoke();
        UpdateScore(5);
    }






    //Main Game Timer --------------------------------------------------------
    IEnumerator GameTimer(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            if (i == 5)
            {
                _startOfGameComms.Invoke();
            }
            if(i == 60)
            {
                _inGameTimeEvent1.Invoke();
            }

            if(i == 146)
            {
                _WarningSFXLights.Invoke();
            }
            if (i == 150)
            {
                _inGameTimeEvent2.Invoke();
            }

            if (i == 200)
            {
                _inGameTimeEvent3.Invoke();
            }
            if (i == 295)
            {
                _endOfTimeEventsFinalBoss.Invoke();
            }
            if (i == 299)
            {
                _inGameTimeEvent4.Invoke();
            }
            i++;
            yield return new WaitForSeconds(1);
        }
    }

    public void StopTheTimer()
    {
        StopAllCoroutines();
        Cursor.visible = true;
    }



    //End Of Game Logic -------------------------------------------------------
    IEnumerator EndGameTimer(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            if(i == 1)
            {
                _eogCommsGo.Invoke();
            }
            if(i == 7)
            {
                _eogStartShipEngings.Invoke();
            }
            if (i == 8)
            {
                _eogLerpForward.Invoke();
            }
            if (i == 15)
            {
                _eogMissionComplete.Invoke();
                _eogStartMusic.Invoke();

            }
            if(i == 20)
            {
                _eogScoreScreen.Invoke();
                Cursor.visible = true;
            }
            if(i == 25)
            {
                _eogPlayAgain.Invoke();
            }
            i++;
            yield return new WaitForSeconds(1);
        }
    }



    //Scene Magament ----------------------------------------------------------
    public void ResetGameButton()
    {
        SceneManager.LoadScene("StoryModeScene");
    }
    public void TilteScreeenButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
