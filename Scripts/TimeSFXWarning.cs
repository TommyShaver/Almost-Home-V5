using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSFXWarning : MonoBehaviour
{
    public GameObject _WarningSFXAndLight;


    public void OnTimeEvents()
    {
        _WarningSFXAndLight.SetActive(true);
    }
}
