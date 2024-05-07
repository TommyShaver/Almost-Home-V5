using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpInUI : MonoBehaviour
{
    private Vector3 startingStoryTextPostion;
    public Vector3 endingStoryTextPostion;
    [SerializeField] float _deisredDuratoin = 5f;
    private float _timeEslped;

    private void Start()
    {
        startingStoryTextPostion = transform.position;
    }
    private void Update()
    {
        _timeEslped += Time.deltaTime;
        float _completedLerp = _timeEslped / _deisredDuratoin;
        transform.position = Vector3.Lerp(startingStoryTextPostion, endingStoryTextPostion, _completedLerp);
    }
}
