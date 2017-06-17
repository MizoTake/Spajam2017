using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

	private bool _hit = false;

	public bool Hit { get { return _hit; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("hit");
		_hit = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		_hit = false;
	}


}
