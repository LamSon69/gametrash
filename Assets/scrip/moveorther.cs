using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveorther : MonoBehaviour
{
    private backgroundfolow background; 
    
    public float movespeed = 3f;

    void Start()
    {
        background = GameObject .Find ("mainground"). GetComponent<backgroundfolow>();
        if (background == null)
        {
            Debug.LogError ("khong tim thay mainground ");
        }
    }

    void Update()
    {
        if (background != null)
        {
            transform .position += Vector3.left * background.speed *Time.deltaTime ;
        }
        float leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).x;
        if (transform.position.x < leftBoundary - 2f )
        {
            gameObject.SetActive(false); 
        }
    }
}
