using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : Singleton<ResultManager>
{
	/// <summary>
	/// 男性の名前入力欄
	/// </summary>
	[SerializeField]
	private InputField _manField;

	/// <summary>
	/// 女性の名前入力欄
	/// </summary>
	[SerializeField]
	private InputField _womanField;

	[SerializeField]
	private Button _nextSceneButton;

	// Use this for initialization
	void Start ()
	{
		_manField.text = UserInfo.ManName;
		_womanField.text = UserInfo.WomanName;
		_nextSceneButton.onClick.AddListener (() => {
			SceneManager.LoadScene ("Start");
		});
	}

	protected override void OnDestroy ()
	{
		UserInfo.ManName = _manField.text;
		UserInfo.WomanName = _womanField.text;
		base.OnDestroy ();
	}
}
