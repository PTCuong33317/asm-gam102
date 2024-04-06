using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
// using UnityEngine.UI.Slider slider;


public class pm2 : MonoBehaviour
{
    //Khai báo biến nhân vật
    public Rigidbody2D rb; //private Rigidbody2D rb;
    public TextMeshProUGUI diemText, highscore;
    private Animator amt;
    int tong;
    public int HightScore;

    public GameObject button, text, panel, textscore; // die
    public GameObject button2, text2, button3; // esc
    public GameObject butllet; //prefab dan
    public Transform bulletPos; // vi tri cua vien dan
    public float timer;
    //Khai báo biến tham số
    //Tốc độ di chuyển
    public float moveSpeed;
    //Tốc độ nhảy
    public float jumpSpeed;
    private bool nendat = true;

    void tinhTong(int score){
        tong += score;
        diemText.text = "Score: " + tong;
    }
    void Start()
    {
        //Gán giá trị mặc định ban đầu cho tốc độ di chuyển, nhảy
        moveSpeed = 6f;
        jumpSpeed = 6.5f;
        rb = GetComponent<Rigidbody2D>();
        amt = GetComponent<Animator>();
       tong = 0;
        HightScore = PlayerPrefs.GetInt("HighScore",0);
        tinhTong(2);
        //Khi chạy, tự tìm 1 Rigidbody2D để gắn vào,
        //Chỉ tìm các component bên trong nó
        //rb = GetComponent<Rigidbody2D>();

       
    }
    void Update()
    {
        //Nếu phím 
        if (Input.GetKeyDown(KeyCode.Space) && nendat) playerJump(jumpSpeed);
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            button.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            panel.SetActive(true);
            text.SetActive(false);
            text2.SetActive(true);
            Time.timeScale = 0;
        }
        if(Input.GetKeyDown(KeyCode.I) && tong > 0){
            PlayerShoot();
        }
        highscore.text = "High Score:" + HightScore;
    }
  
    private void FixedUpdate()
    {
        playerRun(moveSpeed);
    }

    void playerJump(float jumpSpeed)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        nendat = false;
    }

    void playerRun(float moveSpeed)
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    //dieu kien khi va cham voi nen dat
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "nemdat"){
            nendat = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
    if(collision.gameObject.tag == "nemdat"){
        nendat = false;
    }
    }

    //va cham voi coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "coin"){
            var name = collision.attachedRigidbody.name;//goi thang den doi tuong va cham
            Destroy(GameObject.Find(name));
            tinhTong(1);
            // HightScore++;

        }
        if(collision.gameObject.tag == "die"){
            Time.timeScale = 0;
            button.SetActive(true);
            text.SetActive(true);
            panel.SetActive(true);
            button3.SetActive(true);
            if(HightScore > tong){
                HightScore = tong;
                PlayerPrefs.SetInt("HighScore", HightScore);
            }
            textscore.SetActive(true);
        }
        if(collision.gameObject.tag == "boar"){
            Time.timeScale = 0;
            button.SetActive(true);
            text.SetActive(true);
            panel.SetActive(true);
            button3.SetActive(true);
            if(HightScore < tong){
                HightScore = tong;
                PlayerPrefs.SetInt("HighScore", HightScore);
            }
            textscore.SetActive(true);
        }
        if(collision.gameObject.tag == "plant"){
            Time.timeScale = 0;
            button.SetActive(true);
            text.SetActive(true);
            panel.SetActive(true);
            button3.SetActive(true);
            if(HightScore < tong){
                HightScore = tong;
                PlayerPrefs.SetInt("HighScore", HightScore);
            }
            textscore.SetActive(true);
        }
        if(collision.gameObject.tag == "dan"){
            Time.timeScale = 0;
            button.SetActive(true);
            text.SetActive(true);
            panel.SetActive(true);
            button3.SetActive(true);
            if(HightScore < tong){
                HightScore = tong;
                PlayerPrefs.SetInt("HighScore", HightScore);
            }
            textscore.SetActive(true);   
        }
    }
    public void GoOn(){
        Time.timeScale = 1;
        panel.SetActive(false);
        text2.SetActive(false);
        button.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
    }
    public void PlayerShoot(){
        
        Instantiate(butllet, bulletPos.position, Quaternion.identity);
        tinhTong(-1);
    }
     
}