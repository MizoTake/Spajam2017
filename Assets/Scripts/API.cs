using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// APIオブジェクト
/// </summary>
public class API : Singleton<API>
{
	private static readonly string PROTOCOL = "http";
	private static readonly string HOST = "172.31.3.79";
	private static readonly int PORT = 8080;

	private static string HOSTNAME {
		get {
			return PROTOCOL + "://" + HOST + ":" + PORT;
		}
	}

	/// <summary>
	/// APIコール
	/// </summary>
	/// <param name="request">Request.</param>
	private void Send<T> (RequestData<T> request)
	{
		Instance.StartCoroutine (_Send<T> (request));
	}

	/// <summary>
	/// APIコール（コア実装）
	/// </summary>
	/// <param name="request">Request.</param>
	private IEnumerator _Send<T> (RequestData<T> data)
	{
		Debug.Log ("calling api: " + data.request.url);
		yield return data.request.Send ();

		// 通信エラーチェック
		if (data.request.isError) {
			Debug.Log (data.request.error);
		} else {
			// UTF8文字列として取得する
			string text = data.request.downloadHandler.text;
			data.response = JsonUtility.FromJson<T> (text);
			data.OnComplete ();
		}
		yield return 0;
	}

	public static void RankingGet (System.Action<RankingGetDto> onSuccess = null)
	{
		RequestData<RankingGetDto> request = new RequestData<RankingGetDto> (UnityWebRequest.Get (Path.Combine (HOSTNAME, "ranking/get")));
		request.onComplete = onSuccess;
		Instance.Send<RankingGetDto> (request);
	}

	/// <summary>
	/// リクエストデータ
	/// </summary>
	private class RequestData<T>
	{
		/// <summary>
		/// リクエスト
		/// </summary>
		public UnityWebRequest request;

		/// <summary>
		/// レスポンス
		/// </summary>
		public T response;

		/// <summary>
		/// レスポンス受け取り通知
		/// </summary>
		public Action <T> onComplete;

		public RequestData (UnityWebRequest request)
		{
			this.request = request;
		}

		public void OnComplete ()
		{
			if (onComplete != null) {
				onComplete (response);
			}
		}
	}
}
