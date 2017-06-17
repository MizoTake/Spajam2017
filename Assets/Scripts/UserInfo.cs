using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
	private static readonly string PAIR_NAME = "pair-name";

	/// <summary>
	/// ペアの名前
	/// </summary>
	/// <value>The name of the man.</value>
	public static string PairName {
		get { return PlayerPrefs.GetString (PAIR_NAME); }
		set { PlayerPrefs.SetString (PAIR_NAME, value); }
	}
}
