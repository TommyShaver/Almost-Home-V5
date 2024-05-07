using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullets : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPRefab;
    public GameObject bombPrefab;
    public GameObject bombPrefab2;
    public UnityEvent _startCameraShake;
    public UnityEvent _stopCameraShaker;
    public UnityEvent _laser_SFX_Play;
    public UnityEvent _bomb_SFX_Play;
    public UnityEvent _playBombIsReadyAnimationl;

    public float bulletForce = 5f;
    public float bombForce = 1f;

    private PlayerControls _playerControls;
   
    private bool _bombReadyToLanuch;
    private bool _theFirstTimerHasCounted;
    private bool _noBombAnimation; 
    public bool _pauseMenuIsOn = false;
    
    private void Awake()
    {
        _playerControls = GetComponent<PlayerControls>();
        
    }
    private void Start()
    {
        StartCoroutine(BombIsReady(30));
        _theFirstTimerHasCounted = false;
    }
    void Update()
    {

        if (_playerControls._isDead == false)
        {
            if(_pauseMenuIsOn == false)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                }
                if (Input.GetKeyDown(KeyCode.B) && _bombReadyToLanuch == true)
                {
                    if(_noBombAnimation == true)
                    {
                        ShootBombNoAnimation();
                        StartCoroutine(BombIsReady(30));
                    }
                    else
                    {
                        ShootBomb();
                        StartCoroutine(BombIsReady(30));
                    }
                    
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPRefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
        _laser_SFX_Play.Invoke();
    }
    void ShootBomb()
    {
        GameObject bullet = Instantiate(bombPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bombForce, ForceMode2D.Impulse);
        _bomb_SFX_Play.Invoke();
    }
    void ShootBombNoAnimation()
    {
        GameObject bullet = Instantiate(bombPrefab2, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bombForce, ForceMode2D.Impulse);
        _bomb_SFX_Play.Invoke();
    }
    IEnumerator BombIsReady(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            if(i == 2 && _theFirstTimerHasCounted == true)
            {
                _startCameraShake.Invoke();
            }
            if(i == 4 && _theFirstTimerHasCounted == true)
            {
                _stopCameraShaker.Invoke();
            }
            _bombReadyToLanuch = false;
            i++;
            yield return new WaitForSeconds(1);
        }
        _bombReadyToLanuch = true;
        _theFirstTimerHasCounted = true;
        if (_theFirstTimerHasCounted == true)
        {
            _playBombIsReadyAnimationl.Invoke();
        }
    }

    public void PauseIsActive()
    {
        _pauseMenuIsOn = true;  
    }
    public void PauseIsDeActive()
    {
        _pauseMenuIsOn = false;
    }
    public void NoAnimationBomb()
    {
        _noBombAnimation = true;
    }
    public void BombAnimation()
    {
        _noBombAnimation = false;
    }
}
