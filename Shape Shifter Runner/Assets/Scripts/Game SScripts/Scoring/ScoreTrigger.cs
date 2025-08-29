using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] private ScoreScript scoreScript;
    [SerializeField] private  MeshRenderer MeshRenderer;
    [SerializeField] private Material ColourMaterial;

    private float scoreMultiplier = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreScript.SetScoreMultiplyer(scoreMultiplier);
            MeshRenderer.material = ColourMaterial;
            Debug.Log($"Player hit {scoreMultiplier}x zone!");
        }
    }
}
