using System.Threading;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerPC : MonoBehaviour
{
public float moveSpeed = 5f;
public Rigidbody2D rb;
public Animator animator;
UnityEngine.Vector2 vectorMove;
 private SpriteRenderer spriteRenderer;
    void Start()
    {
      
  animator.SetBool("isIdle", true);
   animator.SetBool("isRunning", false);
    spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
     void Update()
    {
      vectorMove.x = Input.GetAxisRaw("Horizontal");  
      vectorMove.y = Input.GetAxisRaw("Vertical");  
       if (vectorMove.x > 0) // Điều kiện kiểm tra hướng
        {
            spriteRenderer.flipX = false; // Không lật hình ảnh (mặt theo bên phải)
        }
        else if (vectorMove.x < 0) // Điều kiện kiểm tra hướng
        {
            spriteRenderer.flipX = true; // Lật hình ảnh (mặt theo bên trái)
        }
     if (vectorMove != UnityEngine.Vector2.zero)
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isRunning", false);
        }

      animator.SetFloat("Speed",vectorMove.sqrMagnitude);
    }
    // Update is called once per frame
     void FixedUpdate()
    {
      rb.MovePosition(rb.position + vectorMove * moveSpeed * Time.fixedDeltaTime) ;  
      
    }
}
