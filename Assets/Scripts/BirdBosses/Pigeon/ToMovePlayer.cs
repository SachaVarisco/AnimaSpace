using UnityEngine;

public class ToMovePlayer : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
             //Debug.LogError("Player object with tag 'Player' is missing in the scene.");
        }
    }

    private void Update(){

        transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
    }
}
