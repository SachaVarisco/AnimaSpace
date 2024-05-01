using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class FoxyBroControl : MonoBehaviour
{
    [SerializeField] private Transform ToMove;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneData.Instance.TutoPass() == false)
        {
            GetComponent<Animator>().SetBool("Move", true);
            transform.DOMoveX(ToMove.position.x, 5).OnComplete(() => Talk());
        }
       
        
    }

    // Update is called once per frame
    private void Talk(){
        GetComponent<Animator>().SetBool("Move", false);
        transform.GetChild(0).gameObject.GetComponent<DialogueControl>().autoDialogue = true;
    }
}
 