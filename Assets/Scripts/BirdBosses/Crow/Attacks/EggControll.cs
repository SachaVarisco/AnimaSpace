using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggControll : MonoBehaviour
{
    [SerializeField] private Transform spawn;
    [SerializeField] private int force;
    [SerializeField] private static UnityEngine.Vector2 LastPos;

    private Animator animator;
    private Rigidbody2D rb2D;

    private void Awake() {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void OnEnable() {
        GetComponent<CircleCollider2D>().enabled = false;
        transform.localScale = new UnityEngine.Vector2(0.2f, 0.2f);
        rb2D.gravityScale = 1;

        float SpawnPosX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        if (LastPos != null)
        {
            transform.position = new UnityEngine.Vector2( SpawnPosX, spawn.position.y);
            LastPos = transform.position;
        }else{
            float rest = SpawnPosX - LastPos.x;
            if (Mathf.Abs(rest) < 0.5f)
            {
                if (rest < 0)
                {
                    SpawnPosX += 2;         
                }else{
                    SpawnPosX -= 2;
                }
            }
            transform.position = new UnityEngine.Vector2( SpawnPosX, spawn.position.y);
            LastPos = transform.position;

        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Walls"){
            rb2D.gravityScale = 0;
            rb2D.velocity = new UnityEngine.Vector2(0, 0);
            animator.SetTrigger("Eggsplotion");
            transform.localScale = new UnityEngine.Vector2(0.5f, 0.5f);
            GetComponent<CircleCollider2D>().enabled = true;
        }
        if (other.gameObject.tag == "Player"){
            
            other.gameObject.GetComponent<PlayerLifeController>().Rebound((transform.position - other.transform.position).normalized);
            Debug.Log("Damage");
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force));
            other.gameObject.GetComponent<PlayerLifeController>().Rebound(other.GetContact(0).normal);
        }
    }
    private IEnumerator Return(){
        yield return new WaitForSeconds(1);
        transform.parent.gameObject.GetComponent<EggPool>().ReturnEgg(gameObject);
    }

}
