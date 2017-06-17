using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Tapde()
    {
        transform.parent.GetComponent<TapObject>().Taped();
        if (transform.parent != null)
        {
            transform.position = new Vector2(-100, -100);
           
            transform.parent = null;
        }
    }
}
