using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float moveDuration = 2f;
    
    [Header("Script Ref")]
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private UiManager uiManager;
    [SerializeField] private ScoreScript scoreScript;

    [Header("Start Pos/Rot")]
    public Vector3 startPos;
    public Quaternion startRot;

    [Header("End Pos/Rot")]
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Quaternion targetRot;

    private float timer;
    private bool isMoving = false;
    private bool setForwardOnComplete = true;

    void Update()
    {
        if (isMoving)
        {
            timer += Time.deltaTime / moveDuration;

            transform.localPosition = Vector3.Lerp(startPos, targetPos, timer);
            transform.localRotation = Quaternion.Slerp(startRot, targetRot, timer);

            if (timer >= 1f)
            {
                isMoving = false;

                if (setForwardOnComplete)
                {
                    movement.isMovingForward = true;
                    movement.moveSideways = true;
                }
                else
                {
                    movement.isMovingForward = false;
                    movement.moveSideways = false;
                    uiManager.SetPoints(scoreScript.GetPoint(), scoreScript.GetMul(), scoreScript.GetPoint() * scoreScript.GetMul());
                }
            }
        }
    }

    private void MoveTo(Vector3 newLocalPos, Quaternion newLocalRot, bool forwardOnComplete)
    {
        startPos = transform.localPosition;
        targetPos = newLocalPos;

        startRot = transform.localRotation;
        targetRot = newLocalRot;

        timer = 0f;
        isMoving = true;

        setForwardOnComplete = forwardOnComplete;
    }

    public void MoveToStart()
    {
        MoveTo(targetPos, targetRot, true);
    }

    public void MoveToScore()
    {
        MoveTo(startPos,startRot, false);
    }
}
