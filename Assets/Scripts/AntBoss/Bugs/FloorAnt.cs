using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloorAnt : MonoBehaviour
{
    [SerializeField] private GameObject Alert;
    [SerializeField] private int force;
    private int count;
    private GameObject Player;
    private void Awake() {
        Player= GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable()
    {
        count = 0;
        Repeat();
    }
    private IEnumerator Wait(){
        float PosY = -2.35f;
        yield return new WaitForSeconds(1f);
        Alert.SetActive(false);
        gameObject.transform.DOMoveY(PosY, 0.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() => Repeat());
        count++;
    }
    private void Repeat(){
        if (count <= 4)
        {
            transform.position = new Vector2(Player.transform.position.x, transform.position.y);
            Alert.SetActive(true);
            StartCoroutine("Wait");
        }else{
            PassState();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force));
        }
    }

    private void PassState(){
        Debug.Log("Pass State");
    }
}

