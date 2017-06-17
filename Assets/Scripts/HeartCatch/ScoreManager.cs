using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager> {

	private int _score;

	public int Score { get { return _score; } set { _score = value; } } 

	// Use this for initialization
	void Start () {
		_score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
