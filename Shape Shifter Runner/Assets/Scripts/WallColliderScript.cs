using UnityEngine;

public class WallColliderScript : MonoBehaviour
{
    public WallScript WallScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(gameObject.name =="RightWall")
            {
                WallScript.RightWallEntered = true;
            }
            else
            {
                WallScript.LeftWallEntered = true;
            }
        }
    }
}
