using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public UnityEvent _musicPaused;
    public UnityEvent _musicResumed;

    public void Paused()
    {
        _musicPaused.Invoke();
        Cursor.visible = true;
    }
    public void Unpaused()
    {
        _musicResumed.Invoke();
        Cursor.visible = false;
    }
}
