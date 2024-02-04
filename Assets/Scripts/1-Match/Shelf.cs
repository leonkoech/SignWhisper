// Shelf.cs
using UnityEngine;

public class Shelf: MonoBehaviour
{
	public bool isOpen = false;
	public string objectName; // Name identifier for the object in the shelf
	public GameObject door; // Assign in Inspector

	public void Open()
	{
		isOpen = true;
		door.SetActive(false); // Open door
	}

	public void Close()
	{
		isOpen = false;
		door.SetActive(true); // Close door
	}
}