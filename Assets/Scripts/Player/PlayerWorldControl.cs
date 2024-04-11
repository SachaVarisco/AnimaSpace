using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldControl : MonoBehaviour
{
    [Header("Move")]
    public float speed;
    private float horizontalMove;
    private float verticalMove;
    
    [Header("Components")]
    private Rigidbody2D rb2D;
    private Animator animator; 

    [Header("Dialogue")]
    public bool talking;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        horizontalMove = speed * Input.GetAxisRaw("Horizontal")  * Time.deltaTime;
        verticalMove = speed * Input.GetAxisRaw("Vertical")  * Time.deltaTime;
        Move();
    }

    private void Move(){
        if (Input.GetAxis("Horizontal")!= 0 && !talking)
        {  
            transform.position += new Vector3(horizontalMove, 0);
            animator.SetFloat("MoveX",Mathf.Abs(horizontalMove));
            
        }
        if (Input.GetAxis("Vertical")!= 0 && !talking )
        {
            transform.position += new Vector3(0, verticalMove);
            animator.SetFloat("MoveY",verticalMove);
        }
    }

}
