using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrbController : MonoBehaviour
{
    [SerializeField] private Transform[] Spawns;

    private Transform PrevSpawn;
    [Header("Path")]
    [SerializeField] private bool Path;
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    private int pathCount;
    private Vector3 pathObj;

    void OnEnable()
    {
        SpawnOrb();
        pathObj = Spawns[pathCount].position;
    }
    private void Update()
    {
        if (Path)
        {
            transform.position = Vector2.MoveTowards(transform.position, pathObj, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, pathObj) < minDistance)
            {
                if (pathCount < Spawns.Length)
                {
                    pathCount++;
                    pathObj = Spawns[pathCount].position;
                }
            }
        }


    }

    private void SpawnOrb()
    {
        if (Path)
        {
            transform.position = Spawns[0].position;
        }
        else
        {
            int index = Random.Range(0, Spawns.Length);
            if (PrevSpawn == null)
            {
                transform.position = Spawns[index].position;
                PrevSpawn = Spawns[index];
            }
            else
            {
                if (PrevSpawn == Spawns[index])
                {
                    transform.position = Spawns[index].position;
                }
                else
                {
                    transform.position = Spawns[index].position;
                }
            }
        }

    }
    private void OnDisable()
    {
        pathCount = 0;

        if (Spawns != null)
        {
            gameObject.transform.position = Spawns[pathCount].position;
        }
        else
        {
            return;
        }

    }
}
