using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// シーン遷移するボタン
/// </summary>
[RequireComponent (typeof(Button))]
public class SceneChangeButton : MonoBehaviour
{
	[SerializeField]
	private string _gotoSceneName;

	private Button _button;

	private void Start ()
	{
		_button = GetComponent<Button> ();
		if (_button != null) {
			_button.onClick.AddListener (() => {
				SceneManager.LoadScene (_gotoSceneName);
			});
		}
	}
}
