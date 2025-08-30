using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private CameraFollow cameraFollow;

    [SerializeField] private float distanceMultiplier;
    [SerializeField] private float ScoreMultiplyer;
    
    private int points;
    private int totalQue;
    private int correctAns;

    private void Start()
    {
        points = 0;
        totalQue = 0;
        correctAns = 0;
        ScoreMultiplyer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveForwardBySpeed(movement.GetCurrentSpeed()));
            
            cameraFollow.moveDuration = 2;
            cameraFollow.MoveToScore();
            points = CalculatePoints();
            Debug.Log("Points "+ points);
        }
    }

    private IEnumerator MoveForwardBySpeed(float speed)
    {
        Debug.Log(speed);
        movement.isMovingForward = true;
        movement.moveSideways = false;

        float targetDistance = speed * distanceMultiplier;
        float moved = 0f;

        while (moved < targetDistance)
        {
            float step = movement.GetCurrentSpeed() * Time.deltaTime;
            moved += step;
            yield return null;
        }

        movement.isMovingForward = false;
    }

    int CalculatePoints()
    {
        if (totalQue == 0) return 0; 
        return Mathf.RoundToInt(((float)correctAns / totalQue) * 100f);
    }

    public void SetScoreMultiplyer(float value)
    {
        ScoreMultiplyer = value;
    }

    public void SetQuestions(int value)
    {
        totalQue = value;
    }

    public void CorrectA()
    {
        correctAns++;
    }

    public int GetPoint()
    {
        return points;
    }

    public float GetMul()
    {
        return ScoreMultiplyer;
    }
}
