using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCollider : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    private int randNum;
    public float LoopTime;

    private void Awake() {
        randNum = Random.Range(0,wayPoints.Length);
    }
    private void Update(){

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[randNum].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoints[randNum].position) < minDistance)
        {
            randNum = Random.Range(0,wayPoints.Length);
        }
    }
}
