using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller  : MonoBehaviour
{
   
    public float attackCooldown = 1.5f; // Thời gian giữa các đòn đánh
    public GameObject projectskill; // Đạn hoặc skill của nhân vật
    public Transform firePoint; // Vị trí bắn skill
    //private bool isAttacking = false; // Kiểm tra có đang tấn công không
    private float nextAttackTime = 0f;
    private Animator anima ;
    private Rigidbody2D rb;
    public bool isAttacking = false; 
    
    void Start()
    {
        anima = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        if (anima == null )
        {
            Debug.LogError("animation chua gan ");
        }
    }

    void Update()
    {
        
        if (!isAttacking) // Nếu không đánh quái, tiếp tục chạy
        {
           anima.SetBool ("isRunning", true);
        }
        else
        {
            anima.SetBool ("isRunning", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && Time.time >= nextAttackTime)
        {
            isAttacking = true; // Dừng chạy để tấn công
            Attack(other.transform); // Gọi hàm tấn công
            nextAttackTime = Time.time + attackCooldown; // Đặt thời gian hồi chiêu
        }
    }

    void Attack(Transform enemy)
    {
        isAttacking = true ; 
        anima .SetTrigger ("Attack");

        
        // Tạo một viên đạn hoặc skill bay về phía quái
        GameObject skillInstance = Instantiate(projectskill, firePoint.position, Quaternion.identity);
        Skill skillcomponent = skillInstance.GetComponent<Skill>(); // Gán mục tiêu

        if ( skillcomponent != null )
        {
            skillcomponent.SetTarget(enemy);
        }
        else 
        {
            Debug.LogError ("Skill is null");
        }

        // Nếu muốn nhân vật dừng trong một khoảng thời gian ngắn rồi tiếp tục chạy:
        Invoke("ContinueRunning", attackCooldown);
    }

    public void ContinueRunning()
    {
        isAttacking = false; // Khi quái chết hoặc cooldown xong, chạy tiếp
    }
}

