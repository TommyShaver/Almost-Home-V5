using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class TimerManager : MonoBehaviour
{
    public UnityEvent _bombTimerBecuaseINotSmart;
    public UnityEvent _clearAnimation;
    private bool _bombIsReadyToLanuch;
    private void Start()
    {
        StartCoroutine(GameTimer(31));
    }

    private void Update()
    {
        if( _bombIsReadyToLanuch == true && Input.GetKeyDown(KeyCode.B))
        {
            _bombIsReadyToLanuch = false;
            StartCoroutine(GameTimer(31));
        }
    }
    IEnumerator GameTimer(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            i++;
            if(i == 30)
            {
                _bombTimerBecuaseINotSmart.Invoke();
            }
            yield return new WaitForSeconds(1);
        }
        _bombIsReadyToLanuch = true;
        _clearAnimation.Invoke();
    }
}
