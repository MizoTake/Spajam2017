using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ランキングのデータ情報
/// </summary>
[Serializable]
public class RankingGetDto
{
	[Serializable]
	public class RakingData {
		public int point;
		public string name;
	}

	public bool result;

	/// <summary>
	/// ランキング情報
	/// </summary>
	public List<RakingData> list;
}
