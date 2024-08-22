using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorComparer : MonoBehaviour
{
    [Header("Components")]
    private SpriteRenderer SR;

    [Header("Comparer")]
    [SerializeField] private Transform rock1;
    [SerializeField] private Transform rock2;


    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {

        if (rock1.position == new Vector3(-3, transform.position.y, 0) && rock2.position == new Vector3(-1, transform.position.y, 0))
        {
            SR.color = Color.green;


        }
    }
}
