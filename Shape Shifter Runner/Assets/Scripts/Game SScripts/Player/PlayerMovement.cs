using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float sensitivity = 0.01f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sideLimit;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerParent;

    [HideInInspector] public bool isMovingForward = false;
    [HideInInspector] public bool moveSideways = true;
    
    private Vector2 lastPos;
    private bool dragging = false;

    void Update()
    {
        if (moveSideways)
        {
            // --- Touch Input (Mobile) ---
            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
            {
                Vector2 currentPos = Touchscreen.current.primaryTouch.position.ReadValue();

                if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
                {
                    lastPos = currentPos;
                }
                else
                {
                    Vector2 delta = currentPos - lastPos;
                    lastPos = currentPos;

                    MovePlayer(delta);
                }
            }

            // --- Mouse Input (PC/Editor Debug) ---
            else if (Mouse.current != null)
            {
                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    lastPos = Mouse.current.position.ReadValue();
                    dragging = true;
                }
                else if (Mouse.current.leftButton.isPressed && dragging)
                {
                    Vector2 currentPos = Mouse.current.position.ReadValue();
                    Vector2 delta = currentPos - lastPos;
                    lastPos = currentPos;

                    MovePlayer(delta);
                }
                else if (Mouse.current.leftButton.wasReleasedThisFrame)
                {
                    dragging = false;
                }
            }
        }

        if (isMovingForward)
        {
            playerParent.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        }
    }

    void MovePlayer(Vector2 delta)
    {
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            float move = delta.x * sensitivity;

            // Move player sideways
            player.Translate(Vector3.right * move, Space.World);

            // Clamp position within limits
            Vector3 pos = player.localPosition;
            pos.x = Mathf.Clamp(pos.x, -sideLimit, sideLimit);
            player.localPosition = pos;
        }
    }

    public void ChangeSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public float GetCurrentSpeed()
    {
        return moveSpeed;
    }
}
