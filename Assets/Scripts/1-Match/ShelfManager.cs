using System.Collections;
using UnityEngine;
using TMPro;
public class ShelfManager : MonoBehaviour
{
	private Shelf firstOpenedShelf = null;

	public void OnShelfOpened(Shelf openedShelf)
	{
		if (firstOpenedShelf == null)
		{
			// This is the first shelf being opened
			firstOpenedShelf = openedShelf;
		}
		else
		{
			// A second shelf is opened, check if they match based on the objectName
			if (openedShelf.objectName == firstOpenedShelf.objectName)
			{
				// Names match, keep both doors open
				firstOpenedShelf = null;
			}
			else
			{
				// Names don't match, close both doors after delay
				StartCoroutine(CloseShelvesAfterDelay(openedShelf, firstOpenedShelf));
				firstOpenedShelf = null;
			}
		}
	}

	private IEnumerator CloseShelvesAfterDelay(Shelf shelf1, Shelf shelf2)
	{
		yield return new WaitForSeconds(1.0f); // Delay for 3 seconds
		if (shelf1.isOpen) shelf1.Close();
		if (shelf2.isOpen) shelf2.Close();
	}
}
