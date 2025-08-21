using UnityEngine;

public class WallColliderScript : MonoBehaviour
{
    public WallScript WallScript;
    public enum WallSide { Left, Right }
    public WallSide side;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (side == WallSide.Right)
                WallScript.RightWallEntered = true;
            else
                WallScript.LeftWallEntered = true;
        }
    }

}
