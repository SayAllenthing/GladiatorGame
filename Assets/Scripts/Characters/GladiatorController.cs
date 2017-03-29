using UnityEngine;
using System.Collections;


public class GladiatorController : MonoBehaviour {

	Gladiator gladiator;

	SpriteRenderer renderer;

	// Use this for initialization
	void Start () {

	}

	public void Init(Gladiator g)
	{
		gladiator = g;

		float height = (float)g.BaseStats.Height/200f;
		float weight = (float)g.BaseStats.Weight/300f;

		Debug.Log("Height = " + height + " BaseHeight = " + (float)g.BaseStats.Height);

		transform.localScale = new Vector3(0.9f + weight, 0.9f + height, 1);

		GetComponent<SpriteRenderer>().color = DataManager.Instance.SkinColours[g.Stats.SkinColour];
	}
	
	public Gladiator GetGladiator()
	{
		return gladiator;
	}
}
