using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallScript : MonoBehaviour
{
    [SerializeField] private Image LeftWallImage;
    [SerializeField] private Image RightWallImage;
    [SerializeField] private Image GateImage;

    [HideInInspector] public ShapeShifterScript shapeShifterScript;
    [HideInInspector] public PlayerMovement movement;
    [HideInInspector] public ScoreScript score;
    public WallManager wallManager;

    [HideInInspector] public int CorrectIdex;
    [SerializeField] private int first;
    [SerializeField] private int second;

    public bool LeftWallEntered;
    public bool RightWallEntered;

    // Safety
    private bool hasChangedShape = false;
    private float changeCooldown = 0.5f; // seconds before another change is allowed
    private float cooldownTimer = 0f;

    private void Start()
    {
        SelectRandomItems();
        LeftWallEntered = false;
        RightWallEntered = false;
    }

    public void SelectRandomItems()
    {
        first = Random.Range(0, wallManager.Images.Count);
        second = Random.Range(0, wallManager.Images.Count);

        if (second == first)
            second = (second + 1) % wallManager.Images.Count;

        LeftWallImage.sprite = wallManager.Images[first];
        RightWallImage.sprite = wallManager.Images[second];

        CorrectIdex = Random.Range(0, 2) == 0 ? first : second;
        GateImage.sprite = wallManager.GateImages[CorrectIdex];

    }

    private void Update()
    {
        // reduce cooldown if active
        if (hasChangedShape)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
                hasChangedShape = false;
        }

        if (!hasChangedShape) // only allow one change per cooldown
        {
            if (LeftWallEntered)
            {
                shapeShifterScript.ChangeShape(first);
                LeftWallEntered = false;
                ActivateCooldown();
            }
            else if (RightWallEntered)
            {
                shapeShifterScript.ChangeShape(second);
                RightWallEntered = false;
                ActivateCooldown();
            }
        }
        else
        {
            // reset triggers while cooldown active
            LeftWallEntered = false;
            RightWallEntered = false;
        }
    }

    private void ActivateCooldown()
    {
        hasChangedShape = true;
        cooldownTimer = changeCooldown;
    }

    public int GetCorrectIndex()
    {
        return CorrectIdex;
    }

    // re-apply sprites based on a forced index
    public void ForceCorrectIndex(int index)
    {
        CorrectIdex = index;
        GateImage.sprite = wallManager.GateImages[index];
    }

}
