using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Slider slider;
    private bool endBattle;

    private void Start()
    {
        slider = GetComponent<Slider>();
        SetLife(4);
        endBattle = false;
    }
    private void Update() {
        if (slider.value <= 0 && !endBattle)
        {
            endBattle = true;
            StartCoroutine(DeadAnim());
        }
    }

    public void SetLife(float maxLife)
    {
        slider.maxValue = maxLife;
    }

    public void SubstractLife(float substract)
    {
        slider.value -= substract;
    }

    public void AddLife(float add)
    {
        slider.value += add;
    }
    private IEnumerator DeadAnim(){
        Animator bossAnim = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        bossAnim.Play("Crow_Dead");
        yield return new WaitForSeconds(1.5f);
        DataPlayer.Instance.Ready = true;
        SceneData.Instance.Winner();
    }
}
