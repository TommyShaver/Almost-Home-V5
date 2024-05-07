using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerectMusicPlayer : MonoBehaviour
{
    public AudioSource _serectSong;

    public void SerectSongStart()
    {
        StartCoroutine(Timer(200));
    }

    IEnumerator Timer(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            i++;
            yield return new WaitForSeconds(1);
        }
        _serectSong.Play();
        

    }
}
