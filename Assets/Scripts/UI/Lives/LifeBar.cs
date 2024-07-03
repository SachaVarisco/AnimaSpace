using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        SetLife(5);
    }
    private void Update() {
        if (slider.value <= 0)
        {
            SceneManager.LoadScene("Victory");
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
}
