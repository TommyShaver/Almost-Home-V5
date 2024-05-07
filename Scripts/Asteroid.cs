using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] _sprites;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;

    public float _minSize = 3;
    public float _maxSize = 20.0f;
    public float _size = 1.0f;
    public float _speed = 50.0f;

    [SerializeField] float _maxLifeTime = 40.0f;
    [SerializeField] AudioSource _audioSource;

    private bool _storyMode;
    private bool _endlessMode;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
        this.transform.eulerAngles = new Vector3(0, 0, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this._size;

        _rb.mass = this._size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        _rb.AddForce(direction * this._speed);
        Destroy(this.gameObject, _maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag == "Laser" || collision.gameObject.tag == "Bomb")
        {
            if((this._size * 0.5f) > this._minSize)
            {
                CreateSplits();
                CreateSplits();
            }
            Destroy(this.gameObject);
            FindObjectOfType<GameManager>().AstroidDestroyed(this);
          
        }
      if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            FindObjectOfType<GameManager>().AstroidDestroyed(this);
        }
     
      if(collision.gameObject.tag == "Rock")
        {
            _audioSource.Play();
        }
    }
    private void CreateSplits()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half._size = this._size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized);
    }

    public void EndlessMode()
    {
        _endlessMode = true;
    }
    public void StoryMode()
    {
        _storyMode = true;
    }
}
