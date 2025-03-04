using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChildren : MonoBehaviour
{
    public Transform targetObject; // Đối tượng camera theo dõi
    public float smoothTime = 0.3f; // Thời gian để camera di chuyển mượt
    private Vector3 velocity = Vector3.zero;
    public float cameraZ = -10f; // Đặt vị trí Z để giữ camera cố định

    void LateUpdate()
    {
        if (targetObject != null)
        {
            // Lấy vị trí trung bình nếu có nhiều child object (nếu dùng nhiều mục tiêu)
            Vector3 targetPosition = GetAveragePosition();

            // SmoothDamp giúp camera di chuyển mượt hơn
            Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // Giữ nguyên trục Z của camera
            newPosition.z = cameraZ;

            // Cập nhật vị trí của camera
            transform.position = newPosition;
        }
        else
        {
            Debug.LogWarning("Target Object is not assigned in FollowChildren.cs!");
        }
    }

    // Tính vị trí trung bình nếu có nhiều đối tượng con
    private Vector3 GetAveragePosition()
    {
        if (targetObject.childCount == 0)
        {
            return targetObject.position; // Nếu không có child, dùng vị trí gốc
        }

        Vector3 totalPosition = Vector3.zero;
        int childrenCount = 0;

        foreach (Transform child in targetObject)
        {
            totalPosition += child.position;
            childrenCount++;
        }

        return totalPosition / childrenCount; // Trả về vị trí trung bình
    }
}
