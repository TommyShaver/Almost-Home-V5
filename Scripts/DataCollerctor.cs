using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DataCollerctor : MonoBehaviour
{
    //Bool -------------------------------------------------------------------
    private bool _bombReadyToLanuch;


    //Public Data ------------------------------------------------------------
    public float _howManyShotsFired = 0;
    public int _howManyBombsShot = 0;
    public float _shotsThatHitRocks = 0;
    public int _howManyShotsWentIntoVoid = 0;
    public int _howManyRocksSpwaned = 0;
    public int _score = 0;
    private float _shotAccuary;

    //Text Mesh Pro ----------------------------------------------------------
    public TMP_Text _tmpShotsFired;
    public TMP_Text _tmpBombsShot;
    public TMP_Text _tmpShotHitRocks;
    public TMP_Text _tmpShotsWentIntoVoid;
    public TMP_Text _tmpRocksSpawned;
    public TMP_Text _tmpScore;
    public TMP_Text _tmpShotAccuracy;

    //Unity Events -----------------------------------------------------------
    public UnityEvent _bomb_SFX_Event_Start;
    public UnityEvent _bomb_SFX_Event_Over;
    public UnityEvent _returnMusic;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BombIsReady(30));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _howManyShotsFired++;
        }
        if (Input.GetKeyDown(KeyCode.B) && _bombReadyToLanuch == true)
        {
            _howManyBombsShot++;
            _bomb_SFX_Event_Start.Invoke();
            StartCoroutine(BombIsReady(30));
        }
    }


    //Bomb Timer -------------------------------------------------------------
    IEnumerator BombIsReady(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            _bombReadyToLanuch = false;
            i++;
            if (i == 4)
            {
                _bomb_SFX_Event_Over.Invoke();
            }
            yield return new WaitForSeconds(1);
        }
        _bomb_SFX_Event_Over.Invoke();
        _bombReadyToLanuch = true;
    }


    // Data and shoot logic --------------------------------------------------
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            _howManyShotsWentIntoVoid++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            _howManyRocksSpwaned++;
        }
    }
    public void ShotDeceted()
    {
        _shotsThatHitRocks++;
    }
    public void PlayerScore()
    {
        _score += 5;
    }


    //Text Mesh Pro Logic ----------------------------------------------------
    public void EogTMPLogic()
    {
        _shotAccuary = _shotsThatHitRocks / _howManyShotsFired * 100;
        Debug.Log(_shotAccuary);
       
        _tmpShotsFired.text = ": " + _howManyShotsFired.ToString();
        _tmpBombsShot.text = ": " + _howManyBombsShot.ToString();
        _tmpShotHitRocks.text = ": " + _shotsThatHitRocks.ToString();
        _tmpShotsWentIntoVoid.text = ": " + _howManyShotsWentIntoVoid.ToString();
        _tmpRocksSpawned.text = ": " + _howManyRocksSpwaned.ToString();
        _tmpScore.text = ": " + _score.ToString();
        _tmpShotAccuracy.text = _shotAccuary.ToString() + "%";
        
    }
}
