using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetEngineS : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] ParticleSystem _particleSystem2;
    [SerializeField] int _partSysCount;
    private bool _animIsPlay;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem2 = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfShipMoved();
        StartTheParticleSystem();

    }

    void CheckIfShipMoved()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _partSysCount = 1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _partSysCount = 0;
        }
    }

    void StartTheParticleSystem()
    {
        if (_partSysCount == 1 && _animIsPlay == false)
        {
            _particleSystem.Play();
            _particleSystem2.Play();
            _animIsPlay = true;
        }
        if (_partSysCount == 0)
        {
            _particleSystem.Stop();
            _particleSystem2.Stop();
            _animIsPlay = false;
        }
    }
}
