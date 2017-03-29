using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public static Player Instance = null;

	public List<Gladiator> Gladiators = new List<Gladiator>();

	public int Denarii = 100;

	// Use this for initialization
	void Start () 
	{
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			DestroyImmediate(this.gameObject);
			return;
		}
	}

	public void AddGladiator(Gladiator g)
	{
		Debug.Log("Gladiator Added " + g.Name);
		Gladiators.Add(g);
		Debug.Log("Gladiators: " + Gladiators.Count);
	}

	public void RemoveGladiator(Gladiator g)
	{
		Gladiators.Remove(g);
	}

	public bool OwnsGladiator(Gladiator g)
	{
		for(int i = 0; i < Gladiators.Count; i++)
		{
			if(g == Gladiators[i])
				return true;
		}

		return false;
	}
}
