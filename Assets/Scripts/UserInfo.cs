using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
	private static readonly string PREFKEY_MAN_NAME = "man-name";
	private static readonly string PREFEKY_WOMAN_NAME = "woman-name";

	/// <summary>
	/// 男性の名前
	/// </summary>
	/// <value>The name of the man.</value>
	public static string ManName {
		get { return PlayerPrefs.GetString (PREFKEY_MAN_NAME); }
		set { PlayerPrefs.SetString (PREFKEY_MAN_NAME, value); }
	}

	/// <summary>
	/// 女性の名前
	/// </summary>
	/// <value>The name of the woman.</value>
	public static string WomanName {
		get { return PlayerPrefs.GetString (PREFEKY_WOMAN_NAME); }
		set { PlayerPrefs.GetString (PREFEKY_WOMAN_NAME, value); }
	}
}
