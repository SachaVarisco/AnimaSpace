using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    [Header ("Crypt")]
    [SerializeField] private bool Crypt;
    [SerializeField] private int ActualLife;
    [SerializeField] private int MaxLife;
    public UnityEvent<int> changeLife;

    [Header ("Audio")]
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
        if (Crypt)
        {
            ActualLife = MaxLife;
            changeLife.Invoke(ActualLife);
        }else{
            Bar = GameObject.FindGameObjectWithTag("Canva").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<BarController>();
        }
    }

    private void Update() {
        if (!CanMove){
            Move.enabled = false;
            Attack.enabled = false;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            CryptDamage();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            CryptHeal();
        }

    }

    public void Rebound(Vector2 ImpactPoint){ //TakeDamage
        if (!CanMove)
        {
            return;
        }
        CanMove = false;
        audioSource.volume = 0.4f;
        audioSource.PlayOneShot(Hurt);
        Bar.PlayerDamaged();
        animator.SetTrigger("Damaged");
        rb2D.velocity = new Vector2(-ImpactVelocity.x * ImpactPoint.x, ImpactVelocity.y);
    }

    private void CanMoveAgain(){
        CanMove = true;
        Move.enabled = true;
        Attack.enabled = true;
    }

    private void CryptDamage(){
        
        int Life = ActualLife - 1;
        if (Life < 0)
        {
            ActualLife = 0; 
        }else{
            ActualLife = Life;
        }
        changeLife.Invoke(ActualLife);
        if (ActualLife <= 0)
        {
            Debug.Log("Death");
        }
    }

    private void CryptHeal(){
        
        int Life = ActualLife + 1;
        if (Life > MaxLife)
        {
            ActualLife = MaxLife;
        }else{
            ActualLife = Life;
        }
        changeLife.Invoke(ActualLife);

    }

}
