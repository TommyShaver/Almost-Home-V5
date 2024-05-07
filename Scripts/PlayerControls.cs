using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    public bool _isDead = false;
    public GameObject _shipDeath;
    public UnityEvent _playerHasFailed;
    public UnityEvent _shipdeathSFX;
    public UnityEvent _shipLosesSheild;

    private BoxCollider2D _boxCollider2D;
    private CapsuleCollider2D _capsuleCollider2D;
    private Rigidbody2D _rb;
    private int _playerHealth = 2;


    //Lerp End Game -----------------------------------------------------------
    [SerializeField] Vector3 _startingPostion;
    [SerializeField] Vector3 _endPostion = new Vector3(0,25,0);
    [SerializeField] float _deisedDuration = 1f;
    [SerializeField] float _timeEsliped;
    private bool _eogSendTheShip;



    //Start of game -----------------------------------------------------------
    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    //Health System ----------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            _rb.velocity = Vector2.zero;
            _playerHealth--;
           if(_playerHealth == 1)
            {
                _shipLosesSheild.Invoke();
            }
            if (_playerHealth == 0)
            {
                _isDead = true;
                Destroy(this.gameObject);
                GameObject effect = Instantiate(_shipDeath, transform.position, Quaternion.identity);
                Destroy(effect, 2f);
                _playerHasFailed.Invoke();
                _shipdeathSFX.Invoke();
            }
        }
    }

    //Sound Effects Lgoic -----------------------------------------------------
    public void BombFXStart()
    {
        _boxCollider2D.enabled = false;
        _capsuleCollider2D.enabled = false;
    }

    public void BombFXEnd()
    {
        _boxCollider2D.enabled = true;
        _capsuleCollider2D.enabled = true;
    }

    //End Of Game Lerp Off Screen ---------------------------------------------
    public void CallForPostion()
    {
        _startingPostion = transform.position;
        _eogSendTheShip = true;
    }
    private void SendTheShip()
    {
        _timeEsliped += Time.deltaTime;
        float _completedLerp = _timeEsliped / _deisedDuration;

        transform.position = Vector3.Lerp(_startingPostion, _endPostion, _completedLerp);
    }
    private void Update()
    {
        if(_eogSendTheShip == true)
        {
            SendTheShip();
            
        }
    }
}
