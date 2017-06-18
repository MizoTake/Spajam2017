using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	[SerializeField]
	private Text _timerText;

	private const int GAME_TIME = 21;
	private float _time;

	// Use this for initialization
	void Start () {
		_time = GAME_TIME;
		StartCoroutine("StartTimer");
	}
	
	// Update is called once per frame
	void Update () {
		_timerText.text = ((int)_time).ToString();
	}

	IEnumerator StartTimer() {
		while(true) {
			_time -= Time.deltaTime;
			if(_time <= 0) {
				SceneManager.LoadScene("Result");
			}
			yield return new WaitForSeconds(0.0f);
		}
	}
}
