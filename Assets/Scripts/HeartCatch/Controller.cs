using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	private const float LR_SIZE = 0.1f;

	[SerializeField]
	private Slider _left;
	[SerializeField]
	private Slider _right;
	[SerializeField]
	private Player _player;

	private bool _leftPressed = false;
	private bool _rightPressed = false;
	private float _beforRight = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_left.value = Mathf.Clamp(_left.value, 0, _beforRight - LR_SIZE);
		_right.value = Mathf.Clamp(_right.value, _left.value + LR_SIZE, 1);

		var average = (_left.value + _right.value) / 2.0f;
		_player.transform.Translate(Vector3.left * (0.5f - average) * 10);

		_beforRight = _right.value;
	}

	public void LeftTapped() {
		_leftPressed = true;
	}

	public void LeftInsideUp() {
		_leftPressed = false;
	}

	public void RightTapped() {
		_rightPressed = true;
	}

	public void RightInsideUp() { 
		_rightPressed = false;
	}
}
