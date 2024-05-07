using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTextLerp : MonoBehaviour
{
    private Animator anim;
    private Vector3 startingStoryTextPostion;
    private Vector3 endingStoryTextPostion = new Vector3(0, 20, 0);
    [SerializeField] float _deisredDuratoin = 1f;
    private float _timeEslped;

    private void Start()
    {
        anim = GetComponent<Animator>();
        startingStoryTextPostion = transform.position;
    }
    private void Update()
    {
        _timeEslped += Time.deltaTime;
        float _completedLerp = _timeEslped / _deisredDuratoin;
        transform.position = Vector3.Lerp(startingStoryTextPostion, endingStoryTextPostion, _completedLerp);
    }

    public void SwitchToFadeOut()
    {
        anim.SetBool("StarStroyTellFade", true);
    }
}
