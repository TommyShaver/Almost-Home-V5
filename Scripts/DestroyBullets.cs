using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyBullets : MonoBehaviour
{
    

    public GameObject _hitEffect;

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rock" || other.gameObject.tag == "Laser" || other.gameObject.tag == "Bomb")
        {
            GameObject _effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(_effect, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Laser_Bounds")
        {
            Destroy(gameObject);
        }
    }
}
