using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLights : MonoBehaviour
{
    public static ShipLights shipLights { get; private set; }
    private Animator _animator;
    private void Awake()
    {
        if (shipLights != null && shipLights != this)
        {
            Destroy(this);
        }
        else
        {
            shipLights = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void EnemyRocksToClose()
    {
        _animator.SetBool("enmeyRockToClose", true);
    }
    public void AllClear()
    {
        _animator.SetBool("enmeyRockToClose", false);
    }
}
