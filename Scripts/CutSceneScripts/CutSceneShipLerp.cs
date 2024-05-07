using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneShipLerp : MonoBehaviour
{
    private Vector3 startingTransfromPostion;
    private Vector3 startingScalePostion;
    private Vector3 endingStoryTextPostion = new Vector3(0, -1.5f, 0);
    private Vector3 endingScalePostion = new Vector3(3,3,1);
    [SerializeField] float _deisredDuratoin = 5f;
    private float _timeEslped;

    private void Start()
    {
        startingTransfromPostion = transform.position;
        startingScalePostion = transform.localScale;
    }
    private void Update()
    {
        _timeEslped += Time.deltaTime;
        float _completedLerp = _timeEslped / _deisredDuratoin;
        transform.position = Vector3.Lerp(startingTransfromPostion, endingStoryTextPostion, _completedLerp);
        transform.localScale = Vector3.Lerp(startingScalePostion, endingScalePostion, _completedLerp);
    }
}

