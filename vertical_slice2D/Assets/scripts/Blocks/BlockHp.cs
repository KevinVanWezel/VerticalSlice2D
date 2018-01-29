using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHp : MonoBehaviour {
    private float hp = 3;
    private SpriteRenderer spR;
    public Sprite damage;
    [SerializeField]
    private ParticleSystem _particle;

    private void Start()
    {
        spR = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ground")
        {
            hp -= 1;
        }
    }
    private void Update()
    {
        if(hp == 1)
        {
            spR.sprite = damage;
        }
        else if (hp <= 0)
        {
            var pSystem = Instantiate(_particle);
            pSystem.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
