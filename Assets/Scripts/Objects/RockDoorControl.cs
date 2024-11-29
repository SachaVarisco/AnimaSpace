using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;

public class RockDoorControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneData.Instance.HaveKey())
            {

                CustomEvent UseKey = new CustomEvent("UseKey")
                {
                    { "keyID", "Grave Key"}
                };

                AnalyticsService.Instance.RecordEvent(UseKey);
                AnalyticsService.Instance.Flush();


                 //Debug.Log("UseKey evento");
                gameObject.SetActive(false);
            }
        }
    }
}