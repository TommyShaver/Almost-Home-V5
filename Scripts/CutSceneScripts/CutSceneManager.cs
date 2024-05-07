using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public UnityEvent haveControlsSlideOn;
    public UnityEvent advanceTextFlash;
    public UnityEvent leftClickWasClickOnce;
    public UnityEvent startScollingText;
    public UnityEvent warningSoundEffect;
    public UnityEvent tomStartTalking;
    public UnityEvent monStartTalking;
    public UnityEvent startFadingOutStroyText;

    private bool clickAbleIsReady;
    private bool clickAbleOnceTrue;

    private void Start()
    {
        StartCoroutine(StartOFCutSceneTimer(4));
    }

    private void Update()
    {
        if(clickAbleIsReady == true)
        {
            LeftClickAdvance();
        }
    }

    private void LeftClickAdvance()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           if(clickAbleOnceTrue == false)
            {
                leftClickWasClickOnce.Invoke();
                StartCoroutine(CutSceneTimer(100));
                clickAbleOnceTrue = true;
            }
            else
            {
                Debug.Log("We Made it Here");
                SceneManager.LoadScene("StoryModeScene");
            }
            clickAbleIsReady = false;
        }
    }

    IEnumerator StartOFCutSceneTimer(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            if (i == 2)
            {
                haveControlsSlideOn.Invoke();
            }
            if (i == 3)
            {
                advanceTextFlash.Invoke();
                clickAbleIsReady = true;
            }
            i++;
            yield return new WaitForSeconds(1);
        }

    }

    IEnumerator CutSceneTimer(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            if(i == 2)
            {
                advanceTextFlash.Invoke();
                clickAbleIsReady = true;
            }
            if(i == 4)
            {
                startScollingText.Invoke();
            }
            if(i == 77)
            {
                startFadingOutStroyText.Invoke();
            }
            if(i== 79)
            {
                warningSoundEffect.Invoke();
            }
            if(i == 80)
            {
                tomStartTalking.Invoke();
            }
            if(i == 84)
            {
                monStartTalking.Invoke();
            }
            if(i == 99)
            {
                SceneManager.LoadScene("StoryModeScene");
            }
            i++;
            yield return new WaitForSeconds(1);
        }
        
    }
}
