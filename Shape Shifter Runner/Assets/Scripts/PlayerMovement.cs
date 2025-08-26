using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float sensitivity = 0.01f;
    public float moveSpeed;  // Speed of forward movement
    public float sideLimit;
    public Transform player;
    public Transform playerParent;

    private Vector2 lastPos;
    private bool dragging = false;
    public bool isMovingForward = false;
    public bool moveSideways = false;

    private void Start()
    {
        isMovingForward = true;
        moveSideways = true;
    }


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
            // --- Mouse Input (Editor Debug) ---
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
}
