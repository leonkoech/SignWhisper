using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchMiniGame 
{
	public class GameController : MonoBehaviour
	{
		public ShelfManager matchingGameManager;

		// Call this when the player interacts with a shelf
		public void SelectShelf(Shelf selectedShelf)
		{
			if (!selectedShelf.isOpen)
			{
				selectedShelf.Open();
				matchingGameManager.OnShelfOpened(selectedShelf);
			}
		}
	}

}


