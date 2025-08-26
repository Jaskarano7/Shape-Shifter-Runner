using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public PlayerMovement movement;
    public float distanceMultiplier = 1f; // how far per speed unit
    public Animator ItemAnimatior;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Current Speed: {movement.moveSpeed}");
            StartCoroutine(MoveForwardBySpeed(movement.moveSpeed));
            //ItemAnimatior.Play("Rotation Animation");
        }
    }

    private System.Collections.IEnumerator MoveForwardBySpeed(float speed)
    {
        movement.isMovingForward = true;
        movement.moveSideways = false;

        // distance = speed × multiplier
        float targetDistance = speed * distanceMultiplier;
        float moved = 0f;

        while (moved < targetDistance)
        {
            float step = movement.moveSpeed * Time.deltaTime; // move according to your normal movement
            moved += step;
            yield return null;
        }

        movement.isMovingForward = false; // stop after reaching distance
    }
}
