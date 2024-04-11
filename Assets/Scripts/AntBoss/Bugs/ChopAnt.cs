using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChopAnt : MonoBehaviour
{
    [Header ("Attack")]
    [SerializeField] private Transform AttackController;
    [SerializeField] private float AttackRadius;

    private SpriteRenderer MyMaterial;
    private SpriteRenderer MyParentMaterial;


    private void Awake() {
        MyMaterial = GetComponent<SpriteRenderer>();
        MyParentMaterial = transform.parent.gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnEnable(){
        MyMaterial.DOFade(1,0.3f);
        MyParentMaterial.DOFade(1,0.3f);
    }
    
    private void Attack()
    {
        Collider2D[] orbs = Physics2D.OverlapCircleAll(AttackController.position, AttackRadius);
        foreach (Collider2D collision in orbs)
        {
            if (collision.CompareTag("Player"))
            {
                //collision.transform.GetComponent<PLayer>().Takedamage();
                Debug.Log("Hit");
            }
        }
        ChangeHead();
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackController.position, AttackRadius);
    }
    private void ChangeHead(){
        MyMaterial.DOFade(0 ,1);
        MyParentMaterial.DOFade(0 ,1);
        transform.parent.gameObject.transform.parent.gameObject.GetComponent<ChopControl>().NewHead();
    }
}
