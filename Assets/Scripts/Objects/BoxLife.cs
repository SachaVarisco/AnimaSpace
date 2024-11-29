using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLife : MonoBehaviour
{
    [SerializeField] private GameObject DialogueHeal;
    private void Start()
    {

    }
    public void ActiveDialogueHeal()
    {
        if (DataPlayer.Instance.ActualLife < 3)
        {

            DialogueHeal.SetActive(true);

        }
    }

    public void Heal()
    {
         //Debug.Log("cura");
        DataPlayer.Instance.CryptHeal();
        //Destroy(gameObject);
    }
}
