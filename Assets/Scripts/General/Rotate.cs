using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool LookLeft = false;
    private float VelocityX;
    //private float VelocityY;
    private Vector3 PrevPosition;
    private void FixedUpdate() 
    {
        CalcSpeed();
        if (VelocityX > 0 && LookLeft /*&& VelocityY == 0*/) 
        {
            RotateX();
        }
        if (VelocityX < 0 && !LookLeft /*&& VelocityY == 0*/)
        {
            RotateX();
        }
    }
    private void CalcSpeed()
    {
        Vector3 currentPosition = transform.position;
        float deltaTime = Time.deltaTime;

        VelocityX = (currentPosition.x - PrevPosition.x) / deltaTime;
        //VelocityY = (currentPosition.y - PrevPosition.y) / deltaTime;

        PrevPosition = currentPosition;
    }
    public void RotateX()
    {
        LookLeft = !LookLeft;

        Vector3 spriteScale = this.gameObject.transform.localScale;
        spriteScale.x *= -1;  // Invertir la escala en X
        this.gameObject.transform.localScale = spriteScale;




        //transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}