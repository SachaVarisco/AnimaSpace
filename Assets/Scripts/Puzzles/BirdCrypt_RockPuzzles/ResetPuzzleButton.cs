using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResetPuzzleButton : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Transform RockBlue1;
    [SerializeField] private Transform RockBlue2;
    [SerializeField] private Transform RockGreen1;
    [SerializeField] private Transform RockGreen2;
    [SerializeField] private Transform RockRed1;
    [SerializeField] private Transform RockRed2;

    [Header("Positions")]
    private Vector2 InitRockBlue1;
    private Vector2 InitRockBlue2;
    private Vector2 InitRockGreen1;
    private Vector2 InitRockGreen2;
    private Vector2 InitRockRed1;
    private Vector2 InitRockRed2;

    [Header("Audio")]
    [SerializeField] private AudioClip Reset;

    [Header("Comparer")]
    [SerializeField] private ColorComparer colorComp;
    [SerializeField] private ColorComparer colorComp1;
    [SerializeField] private ColorComparer colorComp2;

    [Header("Bool")]
    private bool canReset;

    private void Awake()
    {
        canReset = true;
        InitRockBlue1 = RockBlue1.position;
        InitRockBlue2 = RockBlue2.position;

        InitRockGreen1 = RockGreen1.position;
        InitRockGreen2 = RockGreen2.position;

        InitRockRed1 = RockRed1.position;
        InitRockRed2 = RockRed2.position;
    }
    private void Update()
    {
        if (colorComp.ColorComp == 3)
        {
            canReset = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canReset)
        {
            AudioControll.Instance.PlaySound(Reset);
            RockBlue1.position = InitRockBlue1;
            RockBlue2.position = InitRockBlue2;

            RockGreen1.position = InitRockGreen1;
            RockGreen2.position = InitRockGreen2;

            RockRed1.position = InitRockRed1;
            RockRed2.position = InitRockRed2;
            ResetComparers();
        }
    }
    private void ResetComparers()
    {
        colorComp.Reset();
        colorComp1.Reset();
        colorComp2.Reset();
    }
}
