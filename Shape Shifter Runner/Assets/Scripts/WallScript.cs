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
    public int CorrectIdex;
    public int first;
    public int second;

    public bool LeftWallEntered;
    public bool RightWallEntered;

    private void Start()
    {
        SelectRandomItems();
        LeftWallEntered = false;
        RightWallEntered = false;
    }

    void SelectRandomItems()
    {
        first = Random.Range(0, Images.Count);
        second = Random.Range(0, Images.Count);

        if (second == first)
            second = (second + 1) % Images.Count;


        LeftWallImage.sprite = Images[first];
        RightWallImage.sprite = Images[second];
        CorrectIdex = Random.Range(0, 2) == 0 ? first : second;
        GateImage.sprite = GateImages[CorrectIdex];
        Debug.Log($"Correct Index is : {CorrectIdex}");
    }

    private void Update()
    {
        if (LeftWallEntered)
        {
            shapeShifterScript.ChangeShape(first);
            LeftWallEntered = false;  // reset after applying
        }
        else if (RightWallEntered)
        {
            shapeShifterScript.ChangeShape(second);
            RightWallEntered = false; // reset after applying
        }
    }
}
