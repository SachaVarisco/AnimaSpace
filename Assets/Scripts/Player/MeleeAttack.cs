using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private Transform AttackController;
    [SerializeField] private float AttackRadius;

    [Header("Comoponents")]
    private Animator Animator;

    [Header("Type")]

    [SerializeField] private bool Crow;

    [Header("Player sounds")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip Hit;
    [SerializeField] private AudioClip Orb;
    private void Start()
    {
        Animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !GetComponent<CharacterMove>().talking && Time.timeScale == 1f)
        {
            Animator.SetTrigger("Attack");
            AudioControll.Instance.PlaySound(Hit);
        }
    }

    // Update is called once per frame
    private void Attack()
    {
        Collider2D[] orbs = Physics2D.OverlapCircleAll(AttackController.position, AttackRadius);
        foreach (Collider2D collision in orbs)
        {
            if (collision.CompareTag("Orb"))
            {
                //DataPlayer.Instance.orbCount++;
                AudioControll.Instance.PlaySound(Orb);
                if (Crow)
                {
                    LifeBar Bar = GameObject.FindGameObjectWithTag("Canva").transform.GetChild(0).gameObject.GetComponent<LifeBar>();
                    Bar.SubstractLife(1f);
                }
                else
                {
                    BarController Bar = GameObject.FindGameObjectWithTag("Canva").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<BarController>();
                    Bar.Orb();
                    
                }
                collision.gameObject.SetActive(false);

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackController.position, AttackRadius);
    }
}
