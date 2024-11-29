using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [Header("PJ")]
    public bool isDeath = false;
    [Header("Move")]
    public bool talking;
    public float speed;
    private float horizontalMove;

    [Header("Jump")]
    [SerializeField] private float force;
    [SerializeField] private LayerMask isGround;
    [SerializeField] private bool inGround;
    [SerializeField] private Transform groundControl;
    [SerializeField] private Vector3 boxDimension;
    private bool jump = false;

    [Header("Components")]
    private Rigidbody2D rb2D;
    private Animator animator;
    private AudioSource audioSource;

    [Header("Player sounds")]
    [SerializeField] private AudioClip Jump;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        horizontalMove = speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        animator.SetFloat("MoveY", rb2D.velocity.y * Time.deltaTime);
        animator.SetBool("InGround", inGround);
        inGround = Physics2D.OverlapBox(groundControl.position, boxDimension, 0f, isGround);

        if (!isDeath)
        {
            Move(jump);
        }
        jump = false;
    }
    private void Move(bool jump)
    {
        if (Input.GetAxis("Horizontal") != 0 && !talking && Time.timeScale == 1f)
        {
            //audioSource.Play();
            transform.position += new Vector3(horizontalMove, 0);
            animator.SetFloat("MoveX", Mathf.Abs(horizontalMove));
        }
        if (inGround && jump && !talking)
        {
            AudioControll.Instance.PlaySound(Jump);
            inGround = false;
            rb2D.AddForce(new Vector2(0, force));
        }
    }

    public void StopMovement()
    {

        talking = true;

        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", 0);

    }

    public void ResumeMovement()
    {

        talking = false;

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundControl.position, boxDimension);
    }
}
