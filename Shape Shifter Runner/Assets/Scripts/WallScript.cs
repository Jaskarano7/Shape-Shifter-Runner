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
    public int CorrectImage;
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
        CorrectImage = Random.Range(0, 2) == 0 ? first : second;
        GateImage.sprite = GateImages[CorrectImage];
    }

    private void Update()
    {
        if(LeftWallEntered)
        {
            shapeShifterScript.ChangeShape(first);
        }
        else if (RightWallEntered)
        {
            shapeShifterScript.ChangeShape(second);
        }
    }

}
