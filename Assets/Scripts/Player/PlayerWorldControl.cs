using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerWorldControl : MonoBehaviour
{
    [Header("Move")]
    public bool CanMove = false;
    public float speed;
    private float horizontalMove;
    private float verticalMove;
    private Vector2 moveInput;

    [Header("Wild Appears")]
    [SerializeField] private LayerMask wildAppear;

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

    private void Update()
    {
        if (CanMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            verticalMove = Input.GetAxisRaw("Vertical");
            moveInput = new Vector2(horizontalMove, verticalMove).normalized;

            Move();
        }

        else
        {
            horizontalMove = 0;
            verticalMove = 0;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
        }

        if (horizontalMove != 0 || verticalMove != 0)
        {

            CheckForEncounters();

        }


        if (DataPlayer.Instance != null)
        {
            if (DataPlayer.Instance.IsBack == true)
            {
                Debug.Log("carga");
                //transform.position = DataPlayer.Instance.SpawnReturn;
                DataPlayer.Instance.LoadWorldPosition();
            }
        }

    }

    private void FixedUpdate(){

        rb2D.MovePosition(rb2D.position + moveInput * speed * Time.fixedDeltaTime);
    }

    private void Move()
    {
        if (Input.GetAxis("Horizontal") != 0 && !talking)
        {
            //transform.position += new Vector3(horizontalMove, 0);
            animator.SetFloat("MoveX", Mathf.Abs(horizontalMove));

        }
        if (Input.GetAxis("Vertical") != 0 && !talking)
        {
            //transform.position += new Vector3(0, verticalMove);
            animator.SetFloat("MoveY", verticalMove);
        }


    }

    private void CheckForEncounters()
    {

        if (Physics2D.OverlapCircle(transform.position, 0.2f, wildAppear) != null)
        {

            if (Random.Range(1, 801) <= 1)
            {

                SceneData.Instance.Encounters();
                //Debug.Log("Encounter");
            }

        }
    }

}
