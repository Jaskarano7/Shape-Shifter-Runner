using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [Header("Wall Spawning Settings")]
    [SerializeField] private GameObject wallPrefab;        // The wall prefab
    [SerializeField] private Transform wallParent;         // Parent for hierarchy organization

    [SerializeField] private int minWalls = 7;             // Minimum walls
    [SerializeField] private int maxWalls = 12;             // Maximum walls
    [SerializeField] private float wallSpacing = 15;       // Distance between walls

    [Header("Script Reference")]
    [SerializeField] private ShapeShifterScript shifterScript;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private ScoreScript scoreScript;

    [Header("Env Reference")]
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject FinshPlatform;
    
    private List<WallScript> wallScripts = new List<WallScript>();
    
    public List<Sprite> Images;
    public List<Sprite> GateImages;

    void Start()
    {
        SpawnWalls();
    }

    void SpawnWalls()
    {
        int wallCount = Random.Range(minWalls, maxWalls + 1);
        scoreScript.SetQuestions(wallCount);
        ChangePlatformSize(wallCount);

        int previousCorrectIndex = -1;
        int beforePreviousCorrectIndex = -1; // track one more step back

        for (int i = 0; i < wallCount; i++)
        {
            Vector3 spawnPos = wallParent.transform.position + new Vector3(0, 0, i * wallSpacing);
            GameObject wallObj = Instantiate(wallPrefab, spawnPos, Quaternion.identity, wallParent);

            WallScript ws = wallObj.GetComponent<WallScript>();
            wallScripts.Add(ws);

            ws.shapeShifterScript = shifterScript;
            ws.movement = movement;
            ws.score = scoreScript;
            ws.wallManager = GetComponent<WallManager>();

            int safety = 0;
            do
            {
                ws.SelectRandomItems();
                safety++;
                if (safety > 20) break; // emergency break to avoid infinite loop
            }
            while (ws.CorrectIdex == previousCorrectIndex || ws.CorrectIdex == beforePreviousCorrectIndex);

            beforePreviousCorrectIndex = previousCorrectIndex;
            previousCorrectIndex = ws.CorrectIdex;
        }
    }

    void ChangePlatformSize(int wallCount)
    {
        Platform.transform.localScale = new Vector3(1.5f, 1.5f, wallCount * 1.55f);

        Renderer platformRenderer = Platform.GetComponentInChildren<Renderer>();

        if (platformRenderer != null)
        {
            FinshPlatform.transform.position = new Vector3(
                Platform.transform.position.x,
                Platform.transform.position.y,
                platformRenderer.bounds.max.z
            );
        }
        else
        {
            Debug.LogError("No Renderer found on Platform or its children!");
        }
    }
}
