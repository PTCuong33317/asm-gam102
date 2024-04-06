using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class randomMap : MonoBehaviour
{
    public GameObject plant;
    public GameObject boar;

    public List<GameObject> listGround; //Mảng các block bản đồ
    public Transform player;
    public float rangeToCreatObj = 60f; //Khoảng cách để tạo sẵn map và hủy
    
    public List<GameObject> listGroundOld; //Mảng chứa các block map được tạo ra

    Vector3 endPos; //Vi tri cuoi cung
    Vector3 nextPos; //Vi tri tiep theo


    int groundLen;
    int groundHeight;

    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector3(11.0f, 0f, 0f);

        generateBlockMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, endPos) < rangeToCreatObj)
        {
            generateBlockMap();
        }

        GameObject getOneGround = listGroundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > rangeToCreatObj)
        {
            listGroundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }
    }

    void generateBlockMap ()
    {
        for (int i = 0; i < 5; i++)
        {
            float khoangCach = Random.Range(3f, 6f); //Khoảng cách ngẫu nhiên giữa các block
            nextPos = new Vector3(endPos.x + khoangCach, 0f, 0f);

            //Tạo số nguyên ngẫu nhiên trong khoảng từ a-b, không bao gồm b
            int groundID = Random.Range(0, listGround.Count);

            //Tạo ra block bản đồ ngẫu nhiên
            GameObject newGround = Instantiate(listGround[groundID], nextPos, Quaternion.identity, transform);
            listGroundOld.Add(newGround); //THêm miếng đất vừa tạo vào mảng

            switch (groundID)
            {
                case 0: groundLen = 4; groundHeight =2; break;
                case 1: groundLen = 7; groundHeight =2; break;
                case 2: groundLen = 3; groundHeight =2; break;
                case 3: groundLen = 6; groundHeight =2; break;
                case 4: groundLen = 4; groundHeight =2; break;
            }
            float xacSuat = Random.Range(0, 1f);
            if(xacSuat < 0.3f){
                Instantiate(plant, new Vector3(nextPos.x +1, nextPos.y + groundHeight,0), Quaternion.identity);
            }else if(xacSuat > 0.7f){
                Instantiate(boar, new Vector3(nextPos.x +1, nextPos.y + groundHeight,0), Quaternion.identity);
            }

            endPos = new Vector3(nextPos.x + groundLen, 0f, 0f);
        }
    }
}
