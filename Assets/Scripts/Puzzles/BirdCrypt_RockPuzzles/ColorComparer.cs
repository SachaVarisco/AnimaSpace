using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorComparer : MonoBehaviour
{
    [Header("Components")]
    private SpriteRenderer SR;

    [Header("Comparer")]
    [SerializeField] private Transform rock1;
    [SerializeField] private Transform rock2;

    [SerializeField] private Transform slot1;
    [SerializeField] private Transform slot2;
    public static float ColorCount;
    private bool CanCount;

    [Header("Doors")]
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;

    [SerializeField] private AudioClip puzzleComplete;


    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        CanCount = true;

    }
    private void Update()
    {
        if (CanCount)
        {
            if (new Vector2(rock1.position.x, rock1.position.y) == new Vector2(slot1.position.x, slot1.position.y) && new Vector2(rock2.position.x, rock2.position.y) == new Vector2(slot2.position.x, slot2.position.y))
            {
                AudioControll.Instance.PlaySound(puzzleComplete);

                CanCount = false;
                ColorCount++;
                Debug.Log(ColorCount);
                SR.color = new Color(15f / 255f, 144f / 255f, 8f / 255f, 1f);

                rock1.gameObject.GetComponent<RockMove>().enabled = false;
                rock2.gameObject.GetComponent<RockMove>().enabled = false;
            }
        }

        if (ColorCount == 3)
        {
            //desactivar la puerta
            door1.SetActive(false);
            door2.SetActive(true);
        }

    }

}
