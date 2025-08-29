using System.Collections.Generic;
using UnityEngine;

public class HomePage : MonoBehaviour
{
    [SerializeField] private MeshFilter currentMesh;
    public List<Mesh> meshes;

    private int currentIndex = 0;

    public void NextMesh()
    {
        if (meshes == null || meshes.Count == 0) return;

        currentIndex++;

        if (currentIndex >= meshes.Count)
            currentIndex = 0;

        currentMesh.mesh = meshes[currentIndex];
    }
}
