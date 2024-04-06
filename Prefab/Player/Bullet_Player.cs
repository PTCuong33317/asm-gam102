using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet_Player : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(25f, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "nemdat"){
            Destroy(gameObject);
        }
    }
}
