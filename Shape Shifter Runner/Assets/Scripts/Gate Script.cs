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
            /*if(ShapeShifterScript.MeshList.Catagory[0].Items[index].Mesh == )
            {
                Debug.Log("Pass");
            }
            else
            {
                Debug.Log("Fail");
            }*/
        }
    }
}
