using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class HiddenCollider : MonoBehaviour
{
    [SerializeField] private GameObject PanelHidden;
    [SerializeField] private GameObject ColliderWalls;
    private int sortingOrderOnEnter = 0; 
    private int sortingOrderOnExit = -2;

    private TilemapRenderer panelRenderer;

    void Start()
    {
        panelRenderer = GetComponent<TilemapRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelRenderer.sortingOrder = sortingOrderOnEnter;
            PanelHidden.SetActive(true);
            ColliderWalls.SetActive(true);
        }
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelRenderer.sortingOrder = sortingOrderOnExit;
            PanelHidden.SetActive(false);
            ColliderWalls.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
