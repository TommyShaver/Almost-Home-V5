using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingBackground : MonoBehaviour
{
    public static MoveingBackground instance;
    [SerializeField] Vector3 _startPos;
    [SerializeField] float _repeatBackGround;
    [SerializeField] float _backgroundSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        _startPos = transform.position;
        _repeatBackGround = GetComponent<BoxCollider2D>().size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < _startPos.y -_repeatBackGround)
        {
            transform.position = _startPos;
        }
        transform.Translate(_backgroundSpeed * Time.deltaTime * Vector2.down);
    }
}
