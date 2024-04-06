using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boar : MonoBehaviour
{
    public Slider hp;
    private int direction; // 1 la right -1 la left
    private Rigidbody2D rb; // anh xa toi boar
    public float speedBoar; //toc do cua con boar
    // Start is called before the first frame update
    void Start()
    {
        direction = -1; // ban dau con bo di tu phai sang trai
        speedBoar = 3f; //toc do ban dau
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speedBoar * direction, rb.velocity.y, 0);
        HealBar();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "barie"){
            direction *= -1; // doi huong
            rb.gameObject.transform.localScale = new Vector3(rb.gameObject.transform.localScale.x*-1, 1,1);

           
        }
        if (collision.gameObject.tag == "player_bullet")
        {
            hp.value++;
            Destroy(collision.gameObject);
        }
    }
    void HealBar()
    {
        if (hp.value == 2)
        {
            Destroy(gameObject);
        }
    }
}
