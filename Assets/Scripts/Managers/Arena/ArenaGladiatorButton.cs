using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArenaGladiatorButton : MonoBehaviour {

	public Text Label;

	public void SetName(string s)
	{
		Label.text = s;
	}

	void OnClick()
	{
		Debug.Log("This is a test");
	}
}
