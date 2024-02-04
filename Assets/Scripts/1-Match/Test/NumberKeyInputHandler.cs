using UnityEngine;
using UnityEngine.Events;

public class NumberKeyInputHandler : MonoBehaviour
{
	// UnityEvents for each number key
	public UnityEvent onNumber1Pressed;
	public UnityEvent onNumber2Pressed;
	public UnityEvent onNumber3Pressed;
	public UnityEvent onNumber4Pressed;
	public UnityEvent onNumber5Pressed;
	public UnityEvent onNumber6Pressed;
	public UnityEvent onNumber7Pressed;
	public UnityEvent onNumber8Pressed;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1)) onNumber1Pressed.Invoke();
		if (Input.GetKeyDown(KeyCode.Alpha2)) onNumber2Pressed.Invoke();
		if (Input.GetKeyDown(KeyCode.Alpha3)) onNumber3Pressed.Invoke();
		if (Input.GetKeyDown(KeyCode.Alpha4)) onNumber4Pressed.Invoke();
		if (Input.GetKeyDown(KeyCode.Alpha5)) onNumber5Pressed.Invoke();
		if (Input.GetKeyDown(KeyCode.Alpha6)) onNumber6Pressed.Invoke();
		if (Input.GetKeyDown(KeyCode.Alpha7)) onNumber7Pressed.Invoke();
		if (Input.GetKeyDown(KeyCode.Alpha8)) onNumber8Pressed.Invoke();
	}
}