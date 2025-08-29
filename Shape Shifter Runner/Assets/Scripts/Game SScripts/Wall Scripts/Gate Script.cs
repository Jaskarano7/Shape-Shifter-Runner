using System;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    [SerializeField] private WallScript WallScript;
    private ShapeShifterScript shifterScript;

    private void Start()
    {
        shifterScript = WallScript.shapeShifterScript;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(shifterScript.GetPlayerMesh() == WallScript.CorrectIdex)
            {
                float speed = WallScript.movement.GetCurrentSpeed();
                if (speed<= 13)
                {
                    WallScript.movement.ChangeSpeed(speed += 2);
                }
                shifterScript.PlayCorrectSound();
                WallScript.score.CorrectA();
            }
            else
            {
                WallScript.movement.ChangeSpeed(5);
                shifterScript.PlayIncorrectSound();
            }
        }
    }
}
