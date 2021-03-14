using System.Collections.Generic;

using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class GameEnvPlaneDetection : MonoBehaviour
{
	[SerializeField]
	private GameObject planeMarkerAR;

	private ARRaycastManager arRaycastManager;

	// for plane marker
	private List<ARRaycastHit> arPlaneMarkerRaycastHits;
	private Vector2 arPlaneMarkerRaycatStartPosition;

	public bool PlaneMarkerIsActive { get; private set; }

	private void Awake()
	{
		arRaycastManager = FindObjectOfType<ARRaycastManager>();
	}

	private void Start()
	{
		// for plane marker
		PlaneMarkerIsActive = false;
		planeMarkerAR.SetActive(PlaneMarkerIsActive);
		arPlaneMarkerRaycatStartPosition = new Vector2(Screen.width / 2, Screen.height / 2);
		arPlaneMarkerRaycastHits = new List<ARRaycastHit>();
	}

	private void Update()
	{

		ShowPlaneMarker();
	}

	public void MoveToStartPosition(Transform objectAR)
	{
		objectAR.position = planeMarkerAR.transform.position;
	}

	private void ShowPlaneMarker()
	{
		arPlaneMarkerRaycastHits.Clear();
		arRaycastManager.Raycast(arPlaneMarkerRaycatStartPosition, arPlaneMarkerRaycastHits, TrackableType.Planes);

		if(arPlaneMarkerRaycastHits.Count > 0)
		{
			planeMarkerAR.transform.position = arPlaneMarkerRaycastHits[0].pose.position;
			PlaneMarkerIsActive = true;
			planeMarkerAR.SetActive(PlaneMarkerIsActive);
		}
		else
		{
			PlaneMarkerIsActive = false;
			planeMarkerAR.SetActive(PlaneMarkerIsActive);
		}
	}
}
