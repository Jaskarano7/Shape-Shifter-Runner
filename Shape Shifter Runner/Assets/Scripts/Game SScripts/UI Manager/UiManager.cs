using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private CameraFollow cameraFollow;

    [Header("Buttons")]
    [SerializeField] private Button startBt;
    [SerializeField] private Button HomeBt;

    void Start()
    {
        startBt.onClick.AddListener(startGame);
    }

    void startGame()
    {
        cameraFollow.moveToStart();
        startBt.gameObject.SetActive(false);
    }

}
