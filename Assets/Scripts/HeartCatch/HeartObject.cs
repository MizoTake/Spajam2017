using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeartObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Sequence seq = DOTween.Sequence();
		seq.Append(transform.DOScale (Vector3.one, 1.0f));
		//seq.Append(transform.DOMove (new Vector3(Random.Range(300, 1100), -5.0f, 0), 10.0f));
		seq.Append(transform.DOMove (new Vector3(Random.Range(-2, 2), -15.0f, 0), 10.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
