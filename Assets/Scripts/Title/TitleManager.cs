﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : Singleton<TitleManager>
{ 
	[SerializeField]
	private Button _button;

	private void Start ()
	{
		_button.onClick.AddListener (() => {
			SceneManager.LoadScene ("Select");
		});
	}
}
