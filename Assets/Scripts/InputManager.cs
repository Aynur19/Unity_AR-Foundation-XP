using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
	public delegate void DoubleTouchEvent(Vector2 position, float time, float deltaTime);
	public event DoubleTouchEvent OnDoubleTouch;

	public delegate void StartTouchEvent(Vector2 position, float time);
	public event StartTouchEvent OnStartTouch;

	public delegate void EndTouchEvent(Vector2 position, float time, float deltaTime);
	public event EndTouchEvent OnEndTouch;

	private PlayerControls touchControls;

	private void Awake()
	{
		touchControls = new PlayerControls();
	}

	private void OnEnable()
	{
		touchControls.Enable();
	}

	private void OnDisable()
	{
		touchControls.Disable();
	}

	private void Start()
	{
		touchControls.AR.TouchInput.performed += cxt => DoubleTouch(cxt);  
		touchControls.AR.TouchPress.started += ctx => StartTouch(ctx);
		touchControls.AR.TouchPress.canceled += ctx => EndTouch(ctx);
	}

	private void DoubleTouch(InputAction.CallbackContext context)
	{
		if(OnDoubleTouch != null)
		{
			var position = touchControls.AR.TouchPosition.ReadValue<Vector2>();
			Debug.Log($"Double touch {position}");
			OnDoubleTouch(position, (float)context.time, (float)(context.time - context.startTime));
		}
	}

	private void StartTouch(InputAction.CallbackContext context)
	{

		if(OnStartTouch != null)
		{
			var position = touchControls.AR.TouchPosition.ReadValue<Vector2>();
			Debug.Log($"Touch started {position}");
			OnStartTouch(position, (float)context.startTime);
		}
	}

	private void EndTouch(InputAction.CallbackContext context)
	{
		if(OnEndTouch != null)
		{
			var position = touchControls.AR.TouchPosition.ReadValue<Vector2>();
			Debug.Log($"Touch ended {position}");
			OnEndTouch(position, (float)context.time, (float)(context.time - context.startTime));
		}
	}


}
