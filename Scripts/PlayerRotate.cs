using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRotate : MonoBehaviour
{
    //Basic varbiles  -----------------------------------------------------------
    [SerializeField] float _playerRotateSpeed;
    [SerializeField] float _horizontalInput;
    public UnityEvent _pauseGame;
    public UnityEvent _resumeGame;
    private bool _isgamePaused;
    private bool _finalBossHasBeenDefated;
    private PlayerControls _playerHealth;


    //Lerp Back to Zero ---------------------------------------------------------
    private Vector3 targetRotation = new Vector3 (0,0,0);
    float _rotationSpeed = 1f;

    private bool _resetShipRotation;


    // Awake Function
    private void Awake()
    {
        _playerHealth = GetComponent<PlayerControls>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Roate Logic
        if (_playerHealth._isDead == false && _finalBossHasBeenDefated == false)
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(_horizontalInput * _playerRotateSpeed * Time.deltaTime * Vector3.back);

            if(Input.GetKeyDown(KeyCode.P))
            {
                if(_isgamePaused == false)
                {
                    _isgamePaused = true;
                    _pauseGame.Invoke();
                    Time.timeScale = 0;
                }
                else
                {
                    _isgamePaused = false;
                    _resumeGame.Invoke();
                    Time.timeScale = 1;
                }
            }
        }
        if(_resetShipRotation == true)
        {
            // how to lerp rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * _rotationSpeed);
        }
    }
    public void LerpBackToZero()
    {
        _resetShipRotation = true;
        _finalBossHasBeenDefated = true;
    }
}
