using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class IntroSceneManager : MonoBehaviour
{
    public GameObject _titleScreenAndUI;
    public UnityEvent _fadeToBlack;

    private bool _buttonClickedOnce;

    //Lerping Logic ==================================================
    private bool _startLerpingOutUI;
    private Vector3 _titleScreenAndUIPostion;
    private Vector3 _endPostionUILerpUp = new Vector3(0, 20, 0);
    private float _deisredDuratoin = .4f;
    private float _timeEslped;

    // Starting Logic on Scene =======================================
    private void Start()
    {
        Time.timeScale = 1;
        _titleScreenAndUIPostion = _titleScreenAndUI.transform.position;
    }

    //Loading next scene =======================================
    public void StartNextSceneLoad()
    {
        if (_buttonClickedOnce == false)
        {
            StartCoroutine(LoadNextScene(5));
            _buttonClickedOnce = true;
            // fly out button
        }
    }

    private void Update()
    {
        if(_startLerpingOutUI == true)
        {
            _timeEslped += Time.deltaTime;
            float _completedLerp = _timeEslped / _deisredDuratoin;

            _titleScreenAndUI.transform.position = Vector3.Lerp(_titleScreenAndUIPostion, _endPostionUILerpUp, _completedLerp);
        }
    }

    private IEnumerator LoadNextScene(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            _startLerpingOutUI = true;
            if(i == 1)
            {
                
                _fadeToBlack.Invoke();
            }
            if(i == 3)
            {
                SceneManager.LoadScene("CutSceneScene");
            }
            i++;
            yield return new WaitForSeconds(1);
            Debug.Log(i);
        }
    }
}
