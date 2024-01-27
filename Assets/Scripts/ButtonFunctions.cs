using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
	public Relay relay;

	private string joinCode;
	public TMPro.TMP_InputField inputTextMeshPro;

	private TouchScreenKeyboard keyboard;

	public void ShowKeyboard()
	{
		keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
	}


	public void Host()
	{
		print("Hosted");
		relay.AllocateRelay();
	}
	public void Client()
	{
		joinCode = inputTextMeshPro.text;
		print("Joined as Client");
		relay.JoinRelay(joinCode);
	}
}
