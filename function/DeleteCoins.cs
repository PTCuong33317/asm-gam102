using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCoins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "dan"){
            Destroy(collision.gameObject);
        }
    }
}
