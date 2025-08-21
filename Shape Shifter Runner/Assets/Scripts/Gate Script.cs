using System;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public WallScript WallScript;
    public ShapeShifterScript ShapeShifterScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(ShapeShifterScript.CurrentPlayerIndex == WallScript.CorrectIdex)
            {
                Debug.Log("Pass");
            }
            else
            {
                Debug.Log("Fail");
            }
        }
    }
}
