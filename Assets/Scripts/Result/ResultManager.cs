using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ResultManager : Singleton<ResultManager>
{
	/// <summary>
	/// 男性の名前入力欄
	/// </summary>
	[SerializeField]
	private InputField _pairField;

	[SerializeField]
	private Button _nextSceneButton;
	[SerializeField]
	private GameObject _content;
	[SerializeField]
	private GameObject _node;

	// Use this for initialization
	void Start ()
	{
		_pairField.text = UserInfo.PairName;
		_nextSceneButton.onClick.AddListener (() => {
			SceneManager.LoadScene ("Start");
		});

		API.RankingGet((result) => {
			result.list.ForEach((value, i) => {
				var obj = Instantiate(_node, Vector3.zero, Quaternion.identity);
				obj.transform.SetParent(_content.transform, false);
				var node = obj.GetComponent<Node>();
				node.Number = i.ToString();
				node.Name = value.name;
				node.Score = value.point.ToString();
			});
		});
	}

	protected override void OnDestroy ()
	{
		UserInfo.PairName = _pairField.text;
		base.OnDestroy ();
	}
}
