using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : Singleton<HeartManager> {

	private const float CANVAS_RANGE_X = 0.4f;
	private const float CANVAS_RANGE_Y = 0.2f;

	[SerializeField]
	private HeartObject _heart;
	[SerializeField]
	private RectTransform _canvasTransform;

	// Use this for initialization
	void Start () {
		StartCoroutine("InstanceHeart");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator InstanceHeart() {
		while(true) {
			var xRange = _canvasTransform.sizeDelta.x * CANVAS_RANGE_X;
			//float ranX = Random.Range(_canvasTransform.sizeDelta.x - xRange, xRange);
			float ranX = Random.Range(-5, 5);
			var yRange = _canvasTransform.sizeDelta.y * CANVAS_RANGE_Y;
			//float ranY = Random.Range(_canvasTransform.sizeDelta.y - yRange, _canvasTransform.sizeDelta.y);
			float ranY = Random.Range(8, 10);
			var obj = Instantiate(_heart, new Vector2(ranX, ranY), Quaternion.identity);
			obj.transform.parent = transform;
			yield return new WaitForSeconds(3.0f);
		}
	}
}
