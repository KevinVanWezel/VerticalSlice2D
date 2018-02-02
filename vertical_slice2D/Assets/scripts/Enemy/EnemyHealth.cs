using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyHealth : MonoBehaviour
{
   // private AudioScript _audio;
    private int fallDamage;
   

  

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if (Mathf.Abs(other.relativeVelocity.y) > 6f)
        {
            Destroy(this.gameObject);
            
        }
    }
}