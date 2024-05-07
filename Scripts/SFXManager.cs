using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SFXManager : MonoBehaviour
{
    [Header("Laser SFX")]
    [SerializeField] AudioSource _audioSource;
    [Header("Bomb SFX")]
    [SerializeField] AudioSource _audioSource2;
    [Header("Rock Boom 1 SFX")]
    [SerializeField] AudioSource _rockBoomAudioSource;
    [Header("Rock Boom 2 SFX")]
    [SerializeField] AudioSource _rockBoomAudioSource2;
    [Header("Ship Death SFX")]
    [SerializeField] AudioSource _shipDeathAudioSource;
    [Header("Score SFX")]
    [SerializeField] AudioSource _scoreAudioScore;
    [Header("Puase SFX")]
    [SerializeField] AudioSource _pauseAudioSourceSFX;
    [Header("Eog SpaceShip")]
    [SerializeField] AudioSource _eogSpaceShipTakeOff;
    [Header("       ")]
    [Header("Audio Clips")]
    [SerializeField] AudioClip _pause_Start_SFX, _pause_End_SFX, _bomb_SFX, _score_SFX, _laser_SFX, _rock_Boom_SFX, _ship_Death_SFX;

    public UnityEvent _bombFXStart;
    public UnityEvent _bombFXMid;
    public UnityEvent _bombFXEnd;

    private bool _rockBoom1, _rockBoom2 = true;
    private bool _bombSFXIsPlaying;
   

    private void Awake()
    {
        _audioSource.volume = 0.2f;
        _audioSource2.volume = 1;
        _rockBoomAudioSource.volume = .4f;
        _rockBoomAudioSource2.volume = .4f;
    }
   
    public void Bomb_SFX()
    {
        StartCoroutine(BombTimer(4));
        _audioSource2.clip = _bomb_SFX;
        _audioSource2.Play();
        _bombSFXIsPlaying = true;
    }
    public void Score_SFX()
    {
        _scoreAudioScore.volume = 0.1f;
        _scoreAudioScore.clip = _score_SFX;
        _scoreAudioScore.Play();
    }
    public void Laser_SFX()
    {
        float _laserPitch = Random.Range(.8f, 1f);
        _audioSource.volume = 0.2f;
        _audioSource.pitch = _laserPitch;
        _audioSource.clip = _laser_SFX;
        _audioSource.Play();
    }
    public void Rock_Boom_SFX()
    {
        if(_rockBoom1 == false && _rockBoom2 == true)
        {
            RockBoomSFX1();
            _rockBoom1 = true;
            _rockBoom2 = false;
        }
        else if (_rockBoom1 == true && _rockBoom2 == false)
        {
            RockBoomSFX2();
            _rockBoom1 = false;
            _rockBoom2 = true;
        }
    }
    public void Ship_Death_SFX()
    {
        _shipDeathAudioSource.clip = _ship_Death_SFX;
        _shipDeathAudioSource.Play();

        _rockBoomAudioSource.pitch = 0.5f;
        _rockBoomAudioSource.clip = _rock_Boom_SFX;
        _rockBoomAudioSource.Play();
    }
    private void AudioLevelEventStart()
    {
        _audioSource.volume = 0;
        _rockBoomAudioSource.volume = 0;
        _rockBoomAudioSource2.volume = 0;
       
    }
    private void AudioLevelEventEnd()
    {
        _audioSource.volume = 0.2f;
        _rockBoomAudioSource.volume = .4f;
        _rockBoomAudioSource2.volume = .4f;
    }
    private void RockBoomSFX1()
    {
        _rockBoomAudioSource.clip = _rock_Boom_SFX;
        _rockBoomAudioSource.Play();
    }
    private void RockBoomSFX2()
    {
        _rockBoomAudioSource2.clip = _rock_Boom_SFX;
        _rockBoomAudioSource2.Play();
    }
    IEnumerator BombTimer(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            if (i == 1)
            {
                AudioLevelEventStart();
                _bombFXStart.Invoke();
            }
            if (i == 2)
            {
                AudioLevelEventEnd();
                _bombFXMid.Invoke();
            }
            i++;
            yield return new WaitForSeconds(1);
        }
        _bombFXEnd.Invoke();
        _bombSFXIsPlaying = false;
    }

    public void pauseSFXInGame()
    {
        _audioSource.Pause();
        _audioSource2.Pause();
        _rockBoomAudioSource.Pause();
        _rockBoomAudioSource2.Pause();
        _shipDeathAudioSource.Pause();
        _scoreAudioScore.Pause();
        _pauseAudioSourceSFX.clip = _pause_Start_SFX;
        _pauseAudioSourceSFX.Play();
    }
    public void resumeSFXInGame()
    {
        _audioSource.Play();
        if(_bombSFXIsPlaying == true)
        {
            _audioSource2.Play();
        }
        _rockBoomAudioSource.Play();
        _rockBoomAudioSource2.Play();
        _shipDeathAudioSource.Play();
        _scoreAudioScore.Play();
        _pauseAudioSourceSFX.clip = _pause_End_SFX;
        _pauseAudioSourceSFX.Play();
    }
    public void eogSpaceShipTakeOff()
    {
        _eogSpaceShipTakeOff.Play();
    }
}
