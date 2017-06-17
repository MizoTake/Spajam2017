using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private Slider _slider;

	public Slider PSlider { get { return _slider; } set { _slider = value; } }

	// Use this for initialization
	void Start () {
		_slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
