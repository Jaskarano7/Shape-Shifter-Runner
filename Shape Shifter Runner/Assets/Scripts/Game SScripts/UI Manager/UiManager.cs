using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private CameraFollow cameraFollow;

    [Header("Buttons")]
    [SerializeField] private Button StartBt;
    [SerializeField] private Button HomeBt;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI Point;
    [SerializeField] private TextMeshProUGUI FinalPoint;

    [Header("Page")]
    [SerializeField] private GameObject ScorePage;

    void Start()
    {
        StartBt.onClick.AddListener(StartGame);
        HomeBt.onClick.AddListener(HomePage);

        ScorePage.SetActive(false);
    }

    void StartGame()
    {
        cameraFollow.MoveToStart();
        StartBt.gameObject.SetActive(false);
    }

    void HomePage()
    {
        SceneManager.LoadScene("Home Scene");
    }

    public void SetPoints(int point, float mul, float finalPoint)
    {
        Point.text = $"{point} x {mul}";
        FinalPoint.text = finalPoint.ToString();
        ScorePage.SetActive(true);
    }
}
