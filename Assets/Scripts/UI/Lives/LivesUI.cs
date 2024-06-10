using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private List<Image> LivesList;
    [SerializeField] private GameObject LivePrefab;
    [SerializeField] private int ActualLives;
    //[SerializeField] private Sprite[] SoulsArray;
    [SerializeField] private Sprite SoulGood;
    [SerializeField] private Sprite SoulBad;
    public PlayerLifeController playerLife;

    private void Awake() {
        playerLife.changeLife.AddListener(ChangeSouls);
    }

    private void ChangeSouls(int ActualLife){
        
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
            LivesList.Add(Soul.GetComponent<Image>());
        }
        ActualLives = MaxLifeCount - 1;
    }

    private void ChangeLife(int ActualLife){
        if (ActualLife <= ActualLives)
        {
            QuitSoul(ActualLife);
        }else{
            AddSoul(ActualLife);
        }
    }


    private void QuitSoul(int ActualLife){
        for (int i = ActualLives; i >= ActualLife; i--)
        {
           
            ActualLives = i;
            Debug.Log("Quit "+ ActualLives);
            LivesList[i].sprite = SoulBad;
        }
    }
    private void AddSoul(int ActualLife){
        for (int i = ActualLives; i < ActualLife; i++)
        {
            Debug.Log("Add "+ ActualLives);
            ActualLives = i;
            LivesList[i].sprite = SoulGood;
        }
    }
}
