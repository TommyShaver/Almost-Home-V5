using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource _mainMusicTheme;
    public AudioSource _pauseMusicTheme;
    public AudioSource _gameOverTheme;
    public AudioSource _victoryTheme;
    private AudioLowPassFilter _lowPassAudioFilter;
    private IEnumerator _fadein;
    private IEnumerator _fadeout;
    private float _minFrequency = 100f;
    private float _maxFrequency = 20000f;
    private float _fadeInDuration = 3f;
    private float _fadeOutDuration = 1.5f;

    private void Start()
    {
        _lowPassAudioFilter = GetComponent<AudioLowPassFilter>();
    }


    public void StartMusicFilteringDown()
    {
        _fadeout = FadeOut(_lowPassAudioFilter, _fadeOutDuration, _minFrequency);
        StartCoroutine(_fadeout);  
    }

    public void StartMusicFilteringUp()
    {
        StopAllCoroutines();
        _fadein = FadeIn(_lowPassAudioFilter, _fadeInDuration, _maxFrequency);
        StartCoroutine(_fadein);
    }


    IEnumerator FadeIn(AudioLowPassFilter _filter, float _durination, float _tragetFrequency)
    {
        float _timer = 0f;
        float _currentFrequency = _filter.cutoffFrequency;
        float _targetValue = Mathf.Clamp(_tragetFrequency, _minFrequency, _maxFrequency);

        while (_timer < _durination)
        {
            _timer += Time.deltaTime;
            var _newFrequency = Mathf.Lerp(_currentFrequency, _targetValue, _timer / _durination);
            _filter.cutoffFrequency = _newFrequency;
            yield return null;
        }
    }

    IEnumerator FadeOut(AudioLowPassFilter _filter, float _durination, float _tragetFrequency)
    {
        float _timer = 0f;
        float _currentFrequency = _filter.cutoffFrequency;
        float _targetValue = Mathf.Clamp(_tragetFrequency, _minFrequency, _maxFrequency);

        while (_filter.cutoffFrequency > 200)
        {
            _timer += Time.deltaTime;
            var _newFrequency = Mathf.Lerp(_currentFrequency, _targetValue, _timer / _durination);
            _filter.cutoffFrequency = _newFrequency;
            yield return null;
        }
    }

    public void GamePausedMusicFuntion()
    {
        _mainMusicTheme.Pause();
        _pauseMusicTheme.Play();
    }
    public void GameResumedMusicFuntion()
    {
        _mainMusicTheme.Play();
        _pauseMusicTheme.Stop();
        StopAllCoroutines();
        StartMusicFilteringUp();
    }
    public void GameOverMusic()
    {
        StopAllCoroutines();
        _mainMusicTheme.Stop();
        _gameOverTheme.Play();
    }
    public void VictoryMusic()
    {
        _mainMusicTheme.Stop();
        _victoryTheme.Play();
    }
    public void StopAllMusic()
    {
        _mainMusicTheme.Stop();
    }
}
