using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManage : Singleton<MoleManage> {

    public const int MAX_ROW = 3;
    public const int MAX_COL = 5;
    public const float B_POS_X = 140, B_POS_Y = 650;
    public const float B_POS_INTERVAL = 250;
    public float moleInterval;
    public float startInterval;
    public bool flg_Start;
    public int numOfMole;

    public GameObject Button;
    public GameObject Canvas;
    public GameObject Mole;

    public const int MAX_MOLE = MAX_ROW * MAX_COL;


    GameObject[] BUTTONS = new GameObject[MAX_ROW * MAX_COL];
    GameObject[] TAP_MOLE = new GameObject[MAX_MOLE];

	// Use this for initialization
	void Start () {
        int count = 0;
        for (int i = 0; i < MAX_ROW; i++)
        {
            for (int j = 0; j < MAX_COL; j++)
            {
                GameObject obj = Instantiate(Button, new Vector2(B_POS_X + B_POS_INTERVAL * j, B_POS_Y - B_POS_INTERVAL * i),Quaternion.identity);
                obj.transform.parent = Canvas.transform;
                BUTTONS[count] = obj;
                count++;
            }
        }

        for (int i = 0; i < MAX_MOLE; i++)
        {
            GameObject obj = Instantiate(Mole, new Vector2(-100, -100), Quaternion.identity);
            obj.transform.parent = BUTTONS[i].transform ;
            TAP_MOLE[i] = obj;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if( ( startInterval > 2.0f ) && !flg_Start)
        {
            flg_Start = true;
        }
        else
        {
            startInterval += Time.deltaTime;
        }

        if (flg_Start)
        {
            moleInterval += Time.deltaTime;
            if (moleInterval > 1.0f)
            {
                numOfMole = (int)Random.Range(1, 5);
                int cnt = 0;

                for (int i = 0; i <= numOfMole; i++)
                {
                    Debug.Log(moleInterval);
                    int ran = Random.Range(0, BUTTONS.Length);
                    if (!BUTTONS[ran].GetComponent<TapObject>().isHeart)
                    {
                        TAP_MOLE[ran].transform.position = BUTTONS[ran].transform.position;
                        BUTTONS[ran].GetComponent<TapObject>().isHeart = true;
                        TAP_MOLE[ran].transform.parent = BUTTONS[ran].transform;
                    }
                    else {
                        i -= 1;
                        cnt += 1;
                        if (cnt == 5) {
                            break;
                        }
                    }
                }
                moleInterval -= 1.0f;
            }
        }		
	}
}
