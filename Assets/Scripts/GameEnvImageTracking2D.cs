using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class GameEnvImageTracking2D : MonoBehaviour
{
    private ARTrackedImageManager trackedImageManager;

	//[SerializeField]
	//private Animator animGameMode;

	private void Awake()
	{
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
	}

	private void OnEnable()
	{
		trackedImageManager.trackedImagesChanged += OnImageChanged;
	}

	private void OnDisable()
	{
		trackedImageManager.trackedImagesChanged -= OnImageChanged;
	}

	//private void Start()
	//{
	//	animGameMode.SetBool("DragonIsAnimated", true);
	//}

	private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
	{
		foreach(var trackedImage in args.added)
		{
			Debug.Log(trackedImage.name);
		}
	}
}
