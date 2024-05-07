using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEvents : MonoBehaviour
{
    public GameObject _dropTheRocks;
    public GameObject _theBossRock;

    public void TimeEvent120()
    {
        _dropTheRocks.SetActive(true);
    }
    public void TimeEvent300()
    {
        _theBossRock.SetActive(true);
    }
}
