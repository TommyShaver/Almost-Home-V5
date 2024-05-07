using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetEngineA : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] int _partSysCount;
    private bool _animIsPlay;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfShipMoved();
        StartTheParticleSystem();

    }

    void CheckIfShipMoved()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _partSysCount = 1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _partSysCount = 0;
        }
    }

    void StartTheParticleSystem()
    {
        if (_partSysCount == 1 && _animIsPlay == false)
        {
            _particleSystem.Play();
            _animIsPlay = true;
        }
        if (_partSysCount == 0)
        {
            _particleSystem.Stop();
            _animIsPlay = false;
        }
    }
}
