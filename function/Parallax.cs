using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Tilemaps;

public class Parallax : MonoBehaviour
{
    Material mat;//gan voi anh phu len 
    float distance;//khoang cach
    [Range(0f, 0.5f)]
    public float speed = 0.2f;//lam cham

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
