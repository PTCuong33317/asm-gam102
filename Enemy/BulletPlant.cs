using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlant : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // tu dong gan doi tuong
        Destroy(gameObject, 1.3f); // doi tuong gameObject tu dong bien mat sau 3s
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-5f, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "player_bullet"){
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
