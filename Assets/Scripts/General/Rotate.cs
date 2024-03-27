using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool LookLeft = false;
    private float VelocityX;
    private Vector3 PrevPosition;
    private void FixedUpdate() 
    {
        CalcSpeed();
        if (VelocityX > 0 && LookLeft) 
        {
            RotateX();
        }
        if (VelocityX < 0 && !LookLeft)
        {
            RotateX();
        }
    }
    private float CalcSpeed()
    {
        Vector3 currentPosition = transform.position;
        float deltaTime = Time.deltaTime;

        VelocityX = (currentPosition.x - PrevPosition.x) / deltaTime;

        PrevPosition = currentPosition;

        return VelocityX;
    }
    public void RotateX()
    {
        LookLeft = !LookLeft;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}