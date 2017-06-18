using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
	[SerializeField]
	private Button _randomBtn;

	private void Start ()
	{
		_randomBtn.onClick.AddListener (() => {
			List<string> gameNames = new List<string> {
				"HeartCatch",
				"Mole"
			};
			string gameName = gameNames [Random.Range (0, gameNames.Count)];
			switch(gameName) {
					case "HeartCatch":
						SceneManager.Instance.SelectGameType = GameType.HeartCatch;
						break;
					case "Mole":
						SceneManager.Instance.SelectGameType = GameType.Mole;
						break;
				}
			SceneManager.LoadScene(gameName);
		});
	}
}
