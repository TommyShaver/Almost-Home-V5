using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSFXLights : MonoBehaviour
{
    public GameObject _warningSFXLight;

    public void StartWarningSFX()
    {
        _warningSFXLight.SetActive(true);
    }
    public void StopWarningSFX()
    {
        _warningSFXLight.SetActive(false);
    }
}
