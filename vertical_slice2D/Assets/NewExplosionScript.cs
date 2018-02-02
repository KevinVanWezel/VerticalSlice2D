using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewExplosionScript : MonoBehaviour {
    public float explosion_delay = 1f;
    public float explosion_rate = 1f;
    public float explosion_max_size = 15f;
    public float explosion_speed = 5f;
    public float current_radius = 0f;
    private Rigidbody2D rigid;


    bool exploded = false;
    CircleCollider2D explosion_radius;
    // Use this for initialization
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start () {
        
        explosion_radius = gameObject.GetComponent<CircleCollider2D>();
	}

    // Update is called once per frame
    void Update()
    {
        explosion_delay -= Time.deltaTime;
        if (explosion_delay < 0)
        {
            exploded = true;
        }
    }    
    void fixedUpdate(){
        if (exploded == true)
        {
            if (current_radius < explosion_max_size)
            {

                current_radius += explosion_rate;
            }
            else
            {
                Object.Destroy(this.gameObject.transform.parent.gameObject);
            }

                explosion_radius.radius = current_radius;
            
        }
        }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (exploded == true)
        {
            if (col.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                Vector2 target = col.gameObject.transform.position;
                Vector2 bomb = gameObject.transform.position;

                Vector2 direction = 40 * (target - bomb);

                col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x / 2f, direction.y * 10f));

            }
        }
    }
}
