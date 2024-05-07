using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombTimerUI : MonoBehaviour
{

    private Image _image;
    private float _minFillAmount = 0f;
    private float _maxFillAmount = 1f;
    private float _countingTimerUp = 30f;
    private IEnumerator _startCounting;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _image = GetComponent<Image>();
        _image.fillAmount = 0f;
        ClearAllAnimation();
    }
    private void Start()
    {
        _startCounting = StartToFillBombBar(_image, _countingTimerUp, _maxFillAmount);
        StartCoroutine(_startCounting);
    }
    public void ResetCallToTimerFill()
    {
        _animator.SetBool("FillBarTrue", true);
        _animator.SetBool("FillBarAnimation", false);
        _image.fillAmount = 0f;
        _startCounting = StartToFillBombBar(_image, _countingTimerUp, _maxFillAmount);
        StartCoroutine(_startCounting);
    }

    public void PlayFilledBarAnimation()
    {
        _animator.SetBool("FillBarAnimation", true);
        _animator.SetBool("FillBarTrue", false);
    }

    public void ClearAllAnimation()
    {
        _animator.SetBool("FillBarTrue", false);
        _animator.SetBool("FillBarAnimation", false);
        Debug.Log("Bomb Animator was reset");
    }

    // Start is called before the first frame update
    IEnumerator StartToFillBombBar(Image _image, float _durination, float _tragetFill)
    {
        float _timer = 0f;
        float _currentFillAmount = _image.fillAmount;
        float _targetValue = Mathf.Clamp(_tragetFill, _minFillAmount, _maxFillAmount);

        while (_timer < _durination)
        {
            _timer += Time.deltaTime;
            var _newFillAmount = Mathf.Lerp(_currentFillAmount, _targetValue, _timer / _durination);
            _image.fillAmount = _newFillAmount;
            yield return null;
        }
        ClearAllAnimation();
    }
}
