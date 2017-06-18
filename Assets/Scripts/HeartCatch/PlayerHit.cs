using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

	[SerializeField]
	private GameObject _character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_character.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
	}

	void OnTriggerEnter2D(Collider2D other) {
		ScoreManager.Instance.Score += 1;
		Destroy(other.gameObject);
	}


}
