using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class GoombaBug : MonoBehaviour
{
    private float PosX;
    private GameObject Player;

    private void OnEnable()
    {
        Player= GameObject.FindGameObjectWithTag("Player");
        PosX = 5;
        Move();
    }
    private void Death(){
        gameObject.SetActive(false);
        Pool.Instance.RequestPrefab();
    }

    private void Move(){
        if (gameObject.transform.position.x >  Player.transform.position.x)
        {
            PosX *= -1;
            gameObject.transform.DOMoveX(PosX, 2).SetLoops(2, LoopType.Restart).OnComplete(() => Death());
        }else{
            gameObject.transform.DOMoveX(PosX, 2).SetLoops(2, LoopType.Restart).OnComplete( () => Death());
        }
    }
}
