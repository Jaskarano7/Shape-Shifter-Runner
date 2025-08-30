using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomePage : MonoBehaviour
{
    [SerializeField] private MeshFilter currentMesh;
    [SerializeField] private List<Mesh> meshes;

    private int currentIndex = 0;

    [SerializeField] private Button PlayBt;
    [SerializeField] private Button SettingsBt;

    private void Start()
    {
        PlayBt.onClick.AddListener(PlayGame);
    }

    public void NextMesh()
    {
        if (meshes == null || meshes.Count == 0) return;

        currentIndex++;

        if (currentIndex >= meshes.Count)
            currentIndex = 0;

        currentMesh.mesh = meshes[currentIndex];
    }

    void PlayGame()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
