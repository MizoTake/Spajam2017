﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneManager : Singleton<SceneManager>
{
	private bool _isSceneLoading;
	private string _loadingSceneName;
	[SerializeField]
	private string _startSceneName;

	[SerializeField]
	private List<string> _sceneNames;
	
	private GameType _gameType;

	public GameType SelectGameType { get { return _gameType; } set { _gameType = value; } }

	protected override void OnAwake ()
	{
		base.OnAwake ();
		DontDestroyOnLoad (gameObject);
	}

	private void Start ()
	{
		LoadScene (_startSceneName);
		bool fullscreen = true;

		int preferredRefreshRate = 60;

		Screen.SetResolution(1280 , 800, fullscreen, preferredRefreshRate);
	}

	/// <summary>
	/// シーンを読み込みます
	/// </summary>
	/// <returns>The scene.</returns>
	/// <param name="sceneName">Scene name.</param>
	/// <param name="onComplete">On complete.</param>
	public static void LoadScene (string sceneName, Action onComplete = null)
	{
		Instance.StartCoroutine (LoadSceneAsync (sceneName, onComplete));
	}

	/// <summary>
	/// シーンを非同期的に読み込みます
	/// </summary>
	/// <returns>The scene.</returns>
	/// <param name="sceneName">Scene name.</param>
	/// <param name="onComplete">On complete.</param>
	public static IEnumerator LoadSceneAsync (string sceneName, Action onComplete = null)
	{
		if (Instance._isSceneLoading || sceneName == Instance._loadingSceneName) {
			yield break;
		}
		// invalid
		if (!Instance._sceneNames.IsAny ()) {
			Debug.LogError ("scene list empty");
			yield break;
		}

		// invalid
		if (!Instance._sceneNames.Contains (sceneName)) {
			Debug.LogError ("not registed Scene");
			yield break;
		}

		// scene loaded
		UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName (sceneName);
		if (scene.isLoaded) {
			Debug.LogError ("already loadScene");
			yield break;
		}

		Instance._isSceneLoading = true;
		// loading
		Instance._loadingSceneName = sceneName;
		AsyncOperation load = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
		while (!load.isDone) {
			yield return 0;
		}
		Instance._isSceneLoading = false;

		// callback
		if (onComplete != null) {
			onComplete ();
		}
		yield return 0;
	}

	#if UNITY_EDITOR
	[CustomEditor (typeof(SceneManager))]
	public class SceneManagerEditor : Editor
	{
		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();

			if (GUILayout.Button ("Scene List Update")) {
				SceneManager manager = target as SceneManager;
				manager._sceneNames = new List<string> ();

				// setting scene list
				EditorBuildSettings.scenes
					.Where (_ => _.enabled)
					.Select (_ => Path.GetFileNameWithoutExtension (Path.Combine (Directory.GetCurrentDirectory (), _.path)))
					.Where (_ => !string.IsNullOrEmpty (_) && !manager._sceneNames.Contains (_))
					.ForEach (_ => manager._sceneNames.Add (_));

				// invalid startScene
				if (!manager._sceneNames.Contains (manager._startSceneName)) {
					manager._startSceneName = string.Empty;
				}
			}
		}
	}
	#endif
}