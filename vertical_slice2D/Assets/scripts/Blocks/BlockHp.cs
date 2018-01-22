using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHp : MonoBehaviour {
    private float hp = 2;
    private SpriteRenderer spR;
    //[SerializeField]
    public Sprite damage;

    private void Start()
    {
        spR = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("touch" + hp);
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
            Destroy(gameObject);
        }
    }
}
