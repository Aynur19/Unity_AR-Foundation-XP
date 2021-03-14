using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class TestTouch : MonoBehaviour
{
	public InteractableObjectAR ObjectAR;
	private InteractableObjectAR currentObjectAR;
	private List<InteractableObjectAR> objectsAR;

	[SerializeField]
	private GameEnvPlaneDetection planeDetection;

    private InputManager inputManager;
	private Camera mainCamera;

	private void Awake()
	{
        inputManager = InputManager.Instance;
		mainCamera = Camera.main;
		objectsAR = new List<InteractableObjectAR>();
	}

	private void OnEnable()
	{
		inputManager.OnEndTouch += OnEndTouch;
	}

	private void OnDisable()
	{
		inputManager.OnEndTouch -= OnEndTouch;
	}

	private void Move(Vector2 screenPosition, float time)
	{
		var screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, mainCamera.nearClipPlane);
		var worldCoodinates = mainCamera.ScreenToWorldPoint(screenCoordinates);
		worldCoodinates.z = 0;
		transform.position = worldCoodinates;
	}

	private void OnEndTouch(Vector2 screenPosition, float time, float deltaTime)
	{
		Ray ray = mainCamera.ScreenPointToRay(screenPosition);
		var collider = GetDetectedObjectCollider(ray);

		if(collider != null)
		{
			var objectAR = collider.GetComponentInParent<InteractableObjectAR>();

			if(objectAR != null)
			{
				if(objectAR.IsDoubleTouch(time))
				{
					DoubleTouchByInteractableObjectAR(objectAR);
				}
				else if(deltaTime < 0.5)
				{
					Debug.Log($"Time: {deltaTime}");

					SingleTouchByInteractableObjectAR(objectAR);

				}
			}
			else if(deltaTime > 0.5)
			{
				Debug.Log($"Time: {deltaTime}");
				ObjectAR.CanCreated = true;
				Debug.Log($"ObjectAR.CanCreated: {ObjectAR.CanCreated}");

				SlowTouchByEmptySpace();
			}
		}
		else
		{
			if (deltaTime > 0.5)
			{
				Debug.Log($"Time: {deltaTime}");
				ObjectAR.CanCreated = true;
				Debug.Log($"ObjectAR.CanCreated: {ObjectAR.CanCreated}");

				SlowTouchByNotInteractableObjectAR();
			}
		}
	}

	private void SingleTouchByInteractableObjectAR(InteractableObjectAR objectAR)
	{
		DetectObject(objectAR);
	}

	private void DoubleTouchByInteractableObjectAR(InteractableObjectAR objectAR)
	{
		objectAR.TryDestroy();
	}

	private void SlowTouchByNotInteractableObjectAR()
	{
		CreateObjectAR();
	}

	private void SlowTouchByEmptySpace()
	{
		CreateObjectAR();
	}

	private void CreateObjectAR()
	{
		if(SceneManager.GetActiveScene().buildIndex == 1)
		{
			if(planeDetection.PlaneMarkerIsActive)
			{
				Debug.Log($"Collider: null");
				currentObjectAR = Instantiate(ObjectAR, new Vector3(0f, 0f, 0f), ObjectAR.transform.rotation);
				planeDetection.MoveToStartPosition(currentObjectAR.transform);
				currentObjectAR.gameObject.SetActive(true);

				if(currentObjectAR is IAnimatable animatable)
				{
					animatable.Animate();
				}

				objectsAR.Add(currentObjectAR);
			}
		}
	}

	private Collider GetDetectedObjectCollider(Ray ray)
	{
		if(Physics.Raycast(ray, out RaycastHit hit))
		{
			return hit.collider;
		}

		return null;
	}

	private void DetectObject(ObjectAR objectAR)
	{
		if(objectAR is IHighlightable highlightableAR)
		{
			highlightableAR.HighlightingObject(GameEnvConstants.OutlineWidth);
		}
	}
}
