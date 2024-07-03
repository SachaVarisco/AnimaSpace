using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField] private int force;
    private Rigidbody2D rb2D;
    private Vector3 lastVel;
    private Vector3 SpawnPos;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        SpawnPos = transform.position;
    }
    private void OnEnable() {
        transform.position = SpawnPos; 
        rb2D.AddForce(new Vector2(9.8f * 180f, 9.8f * 180f));
    }

    private void Update()
    {
        lastVel = rb2D.velocity;
    }
   private void OnCollisionEnter2D(Collision2D other){
       
        var speed = lastVel.magnitude;
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force));
        }
        var direction = Vector3.Reflect(lastVel.normalized, other.contacts[0].normal);
        rb2D.velocity = direction * Mathf.Max(speed, 1f);     
   }

}
