using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamCoins : MonoBehaviour
{
    public Transform player; // anh xa toi player
    public float nextPosX;
    public float nextPosY; // vi tri se sinh coins
    private float khoangCach; // khong cach coin cach xa player
    public float chieuCao; // chieu cao so voi mat dat
    public float chieuCaoToiThieu;
    public float thoiGian; // bao lau thi ve coin 1 lan
    public int soluongCoin; // so luong coin moi lan ve
    public GameObject coin;
    //do cong hinh sin
    public float chieuCaoSin;
    public float doRongSin;

    public float timer; //theo doi thoi gian

    private Vector3 nextPos; // diem vex dong xu dau tien

    // Start is called before the first frame update
    void Start()
    {
        khoangCach = 20f;
        chieuCaoToiThieu = 2f;
        thoiGian = 5f;
        soluongCoin = 8; 
        veCoin2();
        timer = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= thoiGian)
        {
            veCoin2();
            timer = 0;
        }
    }
    private void veCoin(){
        chieuCao = Random.Range(1f, 2f)  + chieuCaoToiThieu;

        nextPosX = player.position.x + khoangCach;
        chieuCaoSin = 3.5f;
        doRongSin = 3.5f;
        for (int i = 0; i < 7; i++){
            nextPosY = Mathf.Abs(chieuCaoSin* Mathf.Sin(nextPosX/ doRongSin)) + chieuCao;
            Instantiate(coin, new Vector3(nextPosX, nextPosY, 0f), Quaternion.identity, transform);
            nextPosX ++;
        }
    }

    private void veCoin2(){
        nextPos = player.position + new Vector3(khoangCach,0,0f); // xác định vis trí vẽ coin đầu tiên , nó tương ứng với vị trí của player ngay tại thời điểm đó
        int soluongCoin2 = (int)(soluongCoin / 2);
        for(int i = -1 * soluongCoin2; i <= soluongCoin2; i++){
            // y = -a * x * x trong do a quyet dinh do cong
                                                                        //0.11f là hệ số a , 0.1f là độ cong của hình
            Vector3 toaDo = nextPos + new Vector3(i + soluongCoin2, -1 * 0.11f * i * i + 0.1f * soluongCoin * soluongCoin/4, 0f);
            Instantiate(coin, toaDo, Quaternion.identity, transform);
        }
    }
}
