using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject bullet; //prefab vien dan
    public Transform bulletPos; // vi tri cua vien dan
    public float timer;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2f) //dk hon 3s ban dan 1 lan
        {
            animator.SetTrigger("atk");
            timer = 0.0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "player_bullet"){
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    private void PlantShoot(){
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
