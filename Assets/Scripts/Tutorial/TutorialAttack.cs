using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialAttack : MonoBehaviour
{
    [SerializeField] private Transform ToMove;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(ToMove.position.x, 4).OnComplete(() => PassState());
    }

    private void PassState(){
        transform.parent.gameObject.transform.parent.gameObject.GetComponent<TutoStateMachine>().PassState();  
    }
}
 