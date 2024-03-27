using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PillarAnt : MonoBehaviour
{
    private float PosY;
    private float Num;
    [SerializeField] GameObject Alert;

    private GameObject Player;
    // Start is called before the first frame update
    private void Awake() {
        Player= GameObject.FindGameObjectWithTag("Player");
    }
    void OnEnable()
    {
        Num = 2.29f;
        if (gameObject.transform.position.y > Player.transform.position.y)
        {
            Num *= -1;
        }else
        {
            Alert.transform.localScale = new Vector2(Alert.transform.localScale.x, -Alert.transform.localScale.y);;
        }
        Alert.SetActive(true);
        PosY = gameObject.transform.position.y + Num;
        StartCoroutine("Wait");
    }

    private IEnumerator Wait(){
        yield return new WaitForSeconds(1f);
        Alert.SetActive(false);
        gameObject.transform.DOMoveY(PosY, 2).SetLoops(2, LoopType.Yoyo);
    }
}
