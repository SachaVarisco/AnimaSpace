using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    private Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        /*if(transform.parent.gameObject.transform.localScale.x < 0 ){
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }*/
        /*if (Vector2.Distance(transform.position, wayPoints[randNum].position) < maxDistance)
        {
            //speed*=2;
        }*/
    }
}
