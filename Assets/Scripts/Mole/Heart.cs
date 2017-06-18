using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour {

    public Sprite pinkHeart,blueHeart;

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

    public void HeartChange()
    {
        if ((int)Random.Range(0, 2) % 2 == 0)
        {
            GetComponent<Image>().sprite = pinkHeart;
        }
        else
        {
            GetComponent<Image>().sprite = blueHeart;
        }
    }
}
