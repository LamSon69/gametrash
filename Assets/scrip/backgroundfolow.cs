using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundfolow : MonoBehaviour
{
    public playercontroller player ; 
    public float resetPositionX = -10f;
    public float startPositionX = 10f;
    public float speed = 3f ; 

    void Update()
    {
        if (player != null )
        {
            Debug.LogWarning("PlayerController chưa được gán vào BackgroundFollow!");
            return;
        }
        if(!player.isAttacking)
        {
            transform.position += Vector3.left  * speed *Time.deltaTime;
        }

        if (transform.position.x <= resetPositionX)
        {
            transform.position = new Vector3(startPositionX, transform.position.y , transform.position.z);
        }

    }
}