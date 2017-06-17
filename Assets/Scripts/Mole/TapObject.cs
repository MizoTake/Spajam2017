using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapObject : MonoBehaviour {

    public bool isHeart;

	// Use this for initialization
	void Start () {
        isHeart = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Taped()
    {
        isHeart = false;
    }
}
