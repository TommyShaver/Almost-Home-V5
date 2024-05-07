using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject _coliderSwitchStates;

   
    private Bullets _bullets;
    private bool _StartTheBomb;
  
    private void Awake()
    {
        _bullets = GameObject.Find("Spaceship").GetComponent<Bullets>();
        _coliderSwitchStates.GetComponent<CircleCollider2D>().enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BombTimer(3)); 
    }

    void MakeItSmaller()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }
    private void Update()
    {
        if(_StartTheBomb == true)
        {
            StartTheBombThing();
        }
    }
    IEnumerator BombTimer(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            if(i == 1)
            {
                MakeItSmaller();
            }
            
            if (i == 2)
            {
                transform.localScale = new Vector3(1, 1, 0);
                _StartTheBomb = true;
                _coliderSwitchStates.GetComponent<CircleCollider2D>().enabled = true;
            }
            i++;
            yield return new WaitForSeconds(1);
        }
        Destroy(this.gameObject);
    }
    private void StartTheBombThing()
    {
        transform.localScale += new Vector3(4, 4, 0);
    }
}
