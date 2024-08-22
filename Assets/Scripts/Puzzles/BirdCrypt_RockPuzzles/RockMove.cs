using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    [Header("Shooters")]
    [SerializeField] private Transform Up_;
    [SerializeField] private Transform Down_;
    [SerializeField] private Transform Right_;
    [SerializeField] private Transform Left_;

    [Header("Colliders")]
    [SerializeField] private BoxCollider2D Up;
    [SerializeField] private BoxCollider2D Down;
    [SerializeField] private BoxCollider2D Right;
    [SerializeField] private BoxCollider2D Left;
    [SerializeField] private BoxCollider2D player;

    [Header("Raycast")]
    [SerializeField] private float distance;
    private RaycastHit2D rCHit2D;



    [Header("Position")]
    [SerializeField] private float dif;

    [Header("Obstacles")]

    [SerializeField] private Transform[] Obstacles;
    private Vector2 pos;

    private bool CanMove;

    private void Awake()
    {
        CanMove = false;
        pos = transform.position;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Up.IsTouching(player))
            {
                RayBox(Down_.position, Vector2.down);
            }
            if (Down.IsTouching(player))
            {
                RayBox(Up_.position, Vector2.up);
            }
            if (Right.IsTouching(player))
            {
                RayBox(Left_.position, Vector2.left);
            }
            if (Left.IsTouching(player))
            {
                RayBox(Right_.position, Vector2.right);
            }
        }
        if (CanMove)
        {
            transform.position = Vector2.Lerp(transform.position, rCHit2D.collider.gameObject.transform.position, 0.1f);
        }
        
    }

    private void RayBox(Vector2 shooter, Vector2 direction)
    {
        rCHit2D = Physics2D.Raycast(shooter, direction, distance);
        if (rCHit2D.collider.gameObject.tag == "Box")
        {
            CanMove = true;
        }
    }
}
