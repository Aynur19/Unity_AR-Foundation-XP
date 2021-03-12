using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ButtonBackToStart : MonoBehaviour
{
    [SerializeField]
    private Button btnBackToStart;

	private void Start()
    {
        btnBackToStart.onClick.AddListener(() => SceneManager.LoadSceneAsync(0));
    }
}
