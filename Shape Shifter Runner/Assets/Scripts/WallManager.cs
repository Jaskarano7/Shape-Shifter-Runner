using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [Header("Wall Spawning Settings")]
    public GameObject wallPrefab;        // The wall prefab
    public Transform wallParent;         // Parent for hierarchy organization
    public int minWalls = 7;             // Minimum walls
    public int maxWalls = 12;             // Maximum walls
    public float wallSpacing = 5f;       // Distance between walls
    
    private List<WallScript> wallScripts = new List<WallScript>();

    public ShapeShifterScript shifterScript;
    public PlayerMovement movement;

    public GameObject Platform;
    public GameObject FinshPlatform;

    void Start()
    {
        SpawnWalls();
        CheckForSame();
    }

    void SpawnWalls()
    {
        int wallCount = Random.Range(minWalls, maxWalls + 1);
        
        ChangePlatformSize(wallCount);
        
        for (int i = 0; i < wallCount; i++)
        {
            Vector3 spawnPos = wallParent.transform.position + new Vector3(0, 0, i * wallSpacing);
            GameObject wallObj = Instantiate(wallPrefab, spawnPos, Quaternion.identity, wallParent);
            
            WallScript ws = wallObj.GetComponent<WallScript>();
            wallScripts.Add(ws);
            ws.shapeShifterScript = shifterScript;
            ws.movement = movement;
        }
    }

    void CheckForSame()
    {
        for (int i = 0; i < wallScripts.Count; i++)
        {
            while (i > 0 && wallScripts[i].CorrectIdex == wallScripts[i - 1].CorrectIdex)
            {
                wallScripts[i].SelectRandomItems();
            }
        }
    }

    void ChangePlatformSize(int wallCount)
    {
        Platform.transform.localScale = new Vector3(1.5f, 1.5f, wallCount * 1.55f);

        // Get the first renderer from children
        Renderer platformRenderer = Platform.GetComponentInChildren<Renderer>();

        if (platformRenderer != null)
        {
            FinshPlatform.transform.position = new Vector3(
                Platform.transform.position.x,
                Platform.transform.position.y,
                platformRenderer.bounds.max.z   // end of first mesh in world space
            );
        }
        else
        {
            Debug.LogError("No Renderer found on Platform or its children!");
        }
    }
}
