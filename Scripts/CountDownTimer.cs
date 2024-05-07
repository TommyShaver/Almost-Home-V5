using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public float _timeValue = 300;
    public TextMeshProUGUI _timerText;

    // Update is called once per frame
    void Update()
    {
        if(_timeValue > 0)
        {
            _timeValue -= Time.deltaTime;
        }
        else
        {
            _timeValue = 0;
        }

        DisplayTimer(_timeValue);
    }


    void DisplayTimer(float _displayTime)
    {
        if(_displayTime < 0)
        {
            _displayTime = 0;
        }
        float minutes = Mathf.FloorToInt(_displayTime / 60);
        float seconds = Mathf.FloorToInt(_displayTime % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
