using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {

	[SerializeField]
	private Text _number;
	[SerializeField]
	private Text _name;
	[SerializeField]
	private Text _score;

	public string Number { set { _number.text = value; } }
	public string Name { set { _name.text = value; } }
	public string Score { set { _score.text = value; } }
	
}
