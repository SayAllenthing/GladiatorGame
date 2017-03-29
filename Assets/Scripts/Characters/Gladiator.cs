using UnityEngine;
using System.Collections;

public class Gladiator
{
	public enum Experience
	{
		STRENGTH = 0,
		QUICKNESS,
		TOUGHNESS,
		WILLPOWER
	}

	public GladiatorStats Stats;
	public string Name;

	public GladiatorStats.BaseStats BaseStats
	{
		get {return this.Stats.GetStats();}
	}
	// Use this for initialization
	void Start () 
	{
		
	}

	public void Init(Gladiator glad = null)
	{
		if(glad != null)
		{
			Stats = glad.Stats;
		}
		else
		{
			Stats = new GladiatorStats();
		}
		
		Name = Stats.Name;
	}

	public void Init(int seed)
	{		
		Stats = new GladiatorStats(seed);
		Name = Stats.Name;
	}

	public int GetRating()
	{
		int ret = BaseStats.Strength + BaseStats.Quickness + BaseStats.Toughness + BaseStats.Willpower;

		return ret;
	}
	
	public string PrintTraits()
	{
		string s = "";

		for(int i = 0; i < Stats.Traits.Count; i++)
		{
			s += Stats.Traits[i] + " ";
		}

		return s;
	}
}
