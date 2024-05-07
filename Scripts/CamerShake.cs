using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamerShake : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;
    

    private void Awake()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StopShaking();
    }

    public void StartShaking()
    {
        CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 1.0f;
    }

    public void StopShaking()
    {
        CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
    }
}
