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


    private void OnEnable() {
        //DataPlayer.Instance.changeLife.AddListener(ChangeSouls);

        ActualLives = 2;
    }
    public void ChangeSouls(int ActualLife){
        if (!LivesList.Any())
        {
            //Debug.Log(ActualLife);
            CreateSouls(ActualLife);
        }else{
            //Debug.Log(ActualLife);
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
        }
        else{
            if(DataPlayer.Instance.isHeal == true){

                AddSoul(ActualLife);
                DataPlayer.Instance.isHeal = false;
            }
            
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
