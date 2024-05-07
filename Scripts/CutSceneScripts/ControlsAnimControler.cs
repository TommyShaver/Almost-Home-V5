using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsAnimControler : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchToNextAnimation()
    {
        animator.SetBool("ControlCutScnenFadeOut", true);
    }
}
