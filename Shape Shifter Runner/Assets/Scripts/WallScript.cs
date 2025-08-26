using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallScript : MonoBehaviour
{
    public Image LeftWallImage;
    public Image RightWallImage;
    public Image GateImage;

    public List<Sprite> Images;
    public List<Sprite> GateImages;

    public ShapeShifterScript shapeShifterScript;
    public PlayerMovement movement;
    public int CorrectIdex;
    public int first;
    public int second;

    public bool LeftWallEntered;
    public bool RightWallEntered;

    // Safety
    private bool hasChangedShape = false;
    public float changeCooldown = 0.5f; // seconds before another change is allowed
    private float cooldownTimer = 0f;

    private void Start()
    {
        SelectRandomItems();
        LeftWallEntered = false;
        RightWallEntered = false;
    }

    public void SelectRandomItems()
    {
        first = Random.Range(0, Images.Count);
        second = Random.Range(0, Images.Count);

        if (second == first)
            second = (second + 1) % Images.Count;

        LeftWallImage.sprite = Images[first];
        RightWallImage.sprite = Images[second];

        CorrectIdex = Random.Range(0, 2) == 0 ? first : second;
        GateImage.sprite = GateImages[CorrectIdex];

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
}
