using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid _asteroidPrefab;

    [SerializeField] float _trajectoryVariance = 15.0f;
    [SerializeField] float _spawnDistance = 10.0f; 
    [SerializeField] float _spawnRate = 2.0f;
    [SerializeField] int _spawnAmount = 1;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this._spawnRate, this._spawnRate); 
    }


    public void Spawn()
    {
        for(int i = 0; i < this._spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this._spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this._trajectoryVariance, this._trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this._asteroidPrefab, spawnPoint, rotation);
            asteroid._size = Random.Range(asteroid._minSize, asteroid._maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
    public void IncreaeSpwanRate()
    {
        CancelInvoke();
        _spawnRate = 1.5f;
        _spawnAmount = 1;
        InvokeRepeating(nameof(Spawn), this._spawnRate, this._spawnRate);
    }

    public void IncreaeSpwanRateAgain()
    {
        CancelInvoke();
        _spawnRate = 1.5f;
        _spawnAmount = 2;
        InvokeRepeating(nameof(Spawn), this._spawnRate, this._spawnRate);
    }
    public void StopAllSpawners()
    {
        CancelInvoke();
    }
}
