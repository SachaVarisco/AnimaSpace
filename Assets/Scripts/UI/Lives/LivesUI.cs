using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private List<Animator> LivesList;
    [SerializeField] private GameObject LivePrefab;
    [SerializeField] private int ActualLives;

    [SerializeField] private Sprite SoulGood;
    [SerializeField] private Sprite SoulBad;


    private void Start() {
        //DataPlayer.Instance.changeLife.AddListener(ChangeSouls);

    }
    public void ChangeSouls(int ActualLife){
        if (!LivesList.Any())
        {
            CreateSouls(ActualLife);
        }else{
            ChangeLife(ActualLife);
        }
    }

    private void CreateSouls(int MaxLifeCount){
        for (int i = 0; i < MaxLifeCount; i++)
        {
            GameObject Soul = Instantiate(LivePrefab, transform);
            LivesList.Add(Soul.GetComponent<Animator>());
        }
        ActualLives = MaxLifeCount - 1;
    }

    private void ChangeLife(int ActualLife){
        if (ActualLife <= ActualLives)
        {
            QuitSoul(ActualLife);
        }else{
            //AddSoul(ActualLife);
        }
    }


    private void QuitSoul(int ActualLife){
        for (int i = ActualLives; i >= ActualLife; i--)
        {
           
            ActualLives = i;
            LivesList[i].SetBool("Damage", true);
            LivesList[i].SetBool("Heal", false);
        }
    }
    private void AddSoul(int ActualLife){
        for (int i = ActualLives; i < ActualLife; i++)
        {
            ActualLives = i;
            LivesList[i].SetBool("Damage", false);
            LivesList[i].SetBool("Heal", true);
        }
    }
}
