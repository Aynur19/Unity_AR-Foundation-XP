
using UnityEngine;

public class ObjectAR : MonoBehaviour
{ 
	private float lastEndTouchTime;
	private float touchEndDeltaTime;

	public bool lastTouchesIsMulti;

	private void Awake()
	{
		lastEndTouchTime = 0f;
		touchEndDeltaTime = -1f;
		gameObject.SetActive(false);
	}

	public bool IsDoubleTouch(float endTouchTime)
	{
		touchEndDeltaTime = endTouchTime - lastEndTouchTime;
		lastEndTouchTime = endTouchTime;

		if(touchEndDeltaTime < 0.3)
		{
			Debug.Log("Double touch");
			Debug.Log($"lastEndTouchTime: {lastEndTouchTime}");
			Debug.Log($"touchEndDeltaTime: {touchEndDeltaTime}");
			return true;
		}
		else
		{
			Debug.Log("Single touch");
			Debug.Log($"lastEndTouchTime: {lastEndTouchTime}");
			Debug.Log($"touchEndDeltaTime: {touchEndDeltaTime}");
			return false;
		}
	}
}
