using System;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public WallScript WallScript;
    private ShapeShifterScript _shifterScript;

    private void Start()
    {
        _shifterScript = WallScript.shapeShifterScript;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_shifterScript.CurrentPlayerIndex == WallScript.CorrectIdex)
            {
                if(WallScript.movement.moveSpeed < 13)
                {
                    WallScript.movement.moveSpeed += 2;
                }
                _shifterScript.audioSource.PlayOneShot(_shifterScript.Correct);
            }
            else
            {
                WallScript.movement.moveSpeed = 5;
                _shifterScript.audioSource.PlayOneShot(_shifterScript.Wrong);
                /*if (WallScript.movement.moveSpeed > 6)
                {
                    WallScript.movement.moveSpeed -= 2;
                }
                else
                {
                    WallScript.movement.moveSpeed = 5;
                }*/
            }
        }
    }
}
