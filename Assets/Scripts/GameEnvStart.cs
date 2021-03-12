using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnvStart : MonoBehaviour
{
    [SerializeField]
    private Button btnPlaneDetection;

    [SerializeField]
    private Button btnImageTracking2D;

    [SerializeField]
    private Button btnFaceRecognition;

    [SerializeField]
    private Button btnExit;

    // Start is called before the first frame update
    void Start()
    {
        btnExit.onClick.AddListener(() => Application.Quit());
        btnPlaneDetection.onClick.AddListener(() => LoadScene(1));
        btnImageTracking2D.onClick.AddListener(() => LoadScene(2));
        btnFaceRecognition.onClick.AddListener(() => LoadScene(3));
    }

    private void LoadScene(int sceneNumber)
	{
        SceneManager.LoadSceneAsync(sceneNumber);
	}
}
