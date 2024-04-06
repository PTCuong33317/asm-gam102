using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{ 
    private Transform cameraTransform;

    void Start()
    {
        // Tìm kiếm và lấy transform của camera
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Lấy vị trí hiện tại của GameObject
        Vector3 newPosition = transform.position;

        // Set vị trí mới, giữ nguyên trục y
        newPosition.x = cameraTransform.position.x;
        newPosition.z = cameraTransform.position.z;

        // Cập nhật vị trí của GameObject
        transform.position = newPosition;
    }
}
