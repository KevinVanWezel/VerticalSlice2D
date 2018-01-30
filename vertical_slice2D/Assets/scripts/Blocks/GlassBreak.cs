using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBreak : MonoBehaviour {

    [SerializeField]
    private ParticleSystem particle; 
    private float hp = 1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground")
        {
            hp -= 1;
        }
    }
    
    void Update () {
        if (hp <= 0)
        {
            var pSystem = Instantiate(particle);
            pSystem.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
