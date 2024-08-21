using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject Restart;
    [SerializeField] private TMP_Text Text;

    private void View(){
        //Text.SetActive(true);
        //Restart.SetActive(true);
        Text.DOFade(1,1).OnComplete(()=>Rest());
        
        
    }
    private void Rest(){
        Restart.GetComponent<Image>().DOFade(1,2);
        Restart.GetComponent<Button>().enabled = true;
    }
}
