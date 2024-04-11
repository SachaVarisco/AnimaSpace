using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{
    [Header ("Move")]
    private bool CanMove;
    [Header ("Impact")]
    [SerializeField] private Vector2 ImpactVelocity;
    
    [Header("Components")]
    private Rigidbody2D rb2D;
    private Animator animator; 
    private CharacterMove Move;
    private MeleeAttack Attack;
    private BarController Bar;
    void Awake()
    {
        CanMove = true;
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Move = GetComponent<CharacterMove>();
        Attack = GetComponent<MeleeAttack>();
        Bar = GameObject.FindGameObjectWithTag("Canva").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<BarController>();
    }

    private void Update() {
        if (!CanMove){
            Move.enabled = false;
            Attack.enabled = false;
        }
    }

    public void Rebound(Vector2 ImpactPoint){
        if (!CanMove)
        {
            return;
        }
        CanMove = false;
        Bar.PlayerDamaged();
        animator.SetTrigger("Damaged");
        rb2D.velocity = new Vector2(-ImpactVelocity.x * ImpactPoint.x, ImpactVelocity.y);
    }

    private void CanMoveAgain(){
        CanMove = true;
        Move.enabled = true;
        Attack.enabled = true;
    }

}
