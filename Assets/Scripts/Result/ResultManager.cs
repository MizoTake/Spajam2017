﻿using System.Collections;
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
	private Button _enterButton;

	[SerializeField]
	private GameObject _content;
	[SerializeField]
	private GameObject _node;

	// Use this for initialization
	void Start ()
	{
		_pairField.text = UserInfo.PairName;

		_enterButton.onClick.AddListener(() => {
			//ScoreManagerが置いてある前提 (現在：ScoreManagerはDon't Destory Objectではない) : 後ほど修正
			API.RankingUpdate(_pairField.text, ScoreManager.Instance.Score.ToString(), SceneManager.Instance.SelectGameType, (result) => {
				for(int i = 0; i<_content.transform.childCount; i++) {
					Destroy(_content.transform.GetChild(i).gameObject);
				}
				result.list.ForEach((value, i) => {
					var obj = Instantiate(_node, Vector3.zero, Quaternion.identity);
					obj.transform.SetParent(_content.transform, false);
					var node = obj.GetComponent<Node>();
					node.Number = (i + 1).ToString();
					node.Name = value.name;
					node.Score = value.point.ToString();
				});
			});
		});

		API.RankingGet((result) => {
			result.list.ForEach((value, i) => {
				var obj = Instantiate(_node, Vector3.zero, Quaternion.identity);
				obj.transform.SetParent(_content.transform, false);
				var node = obj.GetComponent<Node>();
				node.Number = (i + 1).ToString();
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
