using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloorAnt : MonoBehaviour
{
    [SerializeField] GameObject Alert;
    private int count;
    private GameObject Player;
    private void Awake() {
        Player= GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable()
    {
        /*count = 0;
        while(count < 3)
        {
            Attack();
        }*/
        Attack();
    }

    // Update is called once per frame
    private IEnumerator Wait(){
        float PosY = -2.35f;
        yield return new WaitForSeconds(1.5f);
        Alert.SetActive(false);
        gameObject.transform.DOMoveY(PosY, 0.5f).SetLoops(2, LoopType.Yoyo);
        count++;
    }

    private void Attack(){
        transform.position = new Vector2(Player.transform.position.x, transform.position.y);
        Alert.SetActive(true);
        StartCoroutine("Wait");
    }
}
