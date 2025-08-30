using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTrigger : MonoBehaviour
{
    [Header("Script Ref")]
    [SerializeField] private ScoreScript scoreScript;
    [SerializeField] private ShapeShifterScript shapeShifter;

    [Header("Material Ref")]
    [SerializeField] private  MeshRenderer MeshRenderer;
    [SerializeField] private Material ColourMaterial;

    [SerializeField] private float scoreMultiplier = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreScript.SetScoreMultiplyer(scoreMultiplier);
            MeshRenderer.material = ColourMaterial;
            Debug.Log($"Player hit {scoreMultiplier}x zone!");
            //shapeShifter.PlayCorrectSound();
        }
    }
}
