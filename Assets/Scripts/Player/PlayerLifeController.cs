using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLifeController : MonoBehaviour
{
    [Header("Move")]
    private bool CanMove;
    [Header("Impact")]
    [SerializeField] private Vector2 ImpactVelocity;

    [Header("Components")]
    private Rigidbody2D rb2D;
    private Animator animator;
    private CharacterMove Move;
    private MeleeAttack Attack;
    private BarController Bar;

    [Header("Crypt")]
    [SerializeField] private bool Crypt;

    [Header("Audio")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip Hurt;
    void Awake()
    {
        CanMove = true;
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Move = GetComponent<CharacterMove>();
        Attack = GetComponent<MeleeAttack>();
        audioSource = GetComponent<AudioSource>();

        if (!Crypt)
        {
            Bar = GameObject.FindGameObjectWithTag("Canva").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<BarController>();
        }


    }

    private void Update()
    {
        if (!CanMove)
        {
            Move.enabled = false;
            Attack.enabled = false;
        }
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     DataPlayer.Instance.CryptDamage();
        // }
        // if (Input.GetButtonDown("Fire3"))
        // {
        //     DataPlayer.Instance.CryptHeal();
        // }

    }

    public void Rebound(Vector2 ImpactPoint)
    { //TakeDamage
        if (!CanMove)
        {
            return;
        }
        CanMove = false;
        audioSource.volume = 0.4f;
        audioSource.PlayOneShot(Hurt);
        
        animator.SetTrigger("Damaged");
        rb2D.velocity = new Vector2(-ImpactVelocity.x * ImpactPoint.x, ImpactVelocity.y);
        if (Crypt)
        {
            DataPlayer.Instance.CryptDamage();
        }else
        {
            Bar.PlayerDamaged();
        }
    }

    private void CanMoveAgain()
    {
        CanMove = true;
        Move.enabled = true;
        Attack.enabled = true;
    }


}
