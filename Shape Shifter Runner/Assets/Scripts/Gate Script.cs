using System;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public WallScript WallScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(WallScript.shapeShifterScript.CurrentPlayerIndex == WallScript.CorrectIdex)
            {
                Debug.Log("Pass");
                WallScript.movement.moveSpeed += 2;
            }
            else
            {
                Debug.Log("Fail");
                WallScript.movement.moveSpeed = 5;
            }
        }
    }
}
