using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShifterScript : MonoBehaviour
{
    public MeshFilter CurrentMesh;
    public MeshCollider CurrentCollider;
    public Transform PlayerTransform;
    public MainDataHolder MeshList;

    private void Start()
    {

    }

    public void ChangeShape(int index)
    {
        //int index = EnumToIndex(item);

        CurrentMesh.mesh = MeshList.Catagory[0].Items[index].Mesh;
        CurrentCollider.sharedMesh = MeshList.Catagory[0].Items[index].Mesh;
        PlayerTransform.localScale = new Vector3(MeshList.Catagory[0].Items[index].scale, MeshList.Catagory[0].Items[index].scale, MeshList.Catagory[0].Items[index].scale);
    }

    private int EnumToIndex(FoodItem item)
    {
        switch (item)
        {
            case FoodItem.Burger:
                return 0;
            case FoodItem.Donut: 
                return 1;
            case FoodItem.Hotdog:
                return 2;
            case FoodItem.Pizza:
                return 3;
            case FoodItem.Tacco:
                return 4;
        }
        return -1;
    }

}

public enum FoodItem
{
    Burger,
    Donut,
    Pizza,
    Hotdog,
    Tacco
}