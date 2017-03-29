using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LudusManager : MonoBehaviour {

	public GameObject GladiatorPrefab;
	public List<GameObject> Gladiators = new List<GameObject>();

	public GladiatorInfoPanel InfoPanel;

	// Use this for initialization
	void Start () 
	{
		Init();

		GetComponent<MouseClicker>().onClicked += OnClicked;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Init()
	{
		if(Player.Instance == null)
			return;

		for(int i = 0; i < Player.Instance.Gladiators.Count; i++)
		{
			CreateGladiator(Player.Instance.Gladiators[i]);
		}
	}

	void CreateGladiator(Gladiator g)
	{
		Vector3 pos = new Vector3(-2f + (1f * Gladiators.Count), -2f, 0);

		GameObject glad = GameObject.Instantiate(GladiatorPrefab, pos, Quaternion.identity) as GameObject;
		glad.GetComponent<GladiatorController>().Init(g);

		Gladiators.Add(glad);
	}

	void OnClicked(GameObject g)
	{
		if(g.tag == "Gladiator")
		{
			InfoPanel.Init(g.GetComponent<GladiatorController>().GetGladiator());
		}
	}
}
