using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GladiatorStats
{
	public int CurrentHealth;

	public struct BaseStats
	{
		public int Strength;
		public int Quickness;
		public int Toughness;
		public int Willpower;

		public int HP;

		public int Height;
		public int Weight;
	}
	BaseStats Base;

	public struct Experience
	{
		public Experience(int starting)
		{
			Strength = starting;
			Quickness = starting;
			Toughness = starting;
			Willpower = starting;
		}

		public int Strength;
		public int Quickness;
		public int Toughness;
		public int Willpower;
	}
	Experience Exp;

	public int SkinColour = 0;	
	public string Name = "Spartacus";
	public List<string> Traits = new List<string>();

	int MinHeight = 160;
	int MinWeight = 50;

	//Min Plus Max = True Max
	int MaxHeight = 40;
	int MaxWeight = 50;

	private int BonusStats = 0;

	System.Random RandGen;

	public int Seed = -1;

	public GladiatorStats(int seed = -1)
	{
		if(seed < 0)
			seed = Random.Range(0, 9999999);

		Seed = seed;

		RandGen = new System.Random(seed);

		GenerateBaseStats();
		GenerateRacialTraits();
		GeneratePhysicalTraits();
		GenerateName();

		Exp = new Experience(0);
	}

	public BaseStats GetStats()
	{
		return Base;
	}

	public int GetHeight()
	{
		return Base.Height + MinHeight;
	}

	public int GetWeight()
	{
		return Base.Weight + MinWeight;
	}

	public int GetRawHeight()
	{
		return Base.Height;
	}

	public int GetRawWeight()
	{
		return Base.Weight;
	}

	private void IncreaseStat(int stat, int amount = 1)
	{
		switch(stat)
		{
		case 0: Base.Strength += amount; break;
		case 1: Base.Quickness += amount; break;
		case 2: Base.Toughness += amount; break;
		case 3: Base.Willpower += amount; break;
		}
	}

	private int GetStat(int stat)
	{
		switch(stat)
		{
		case 0: return Base.Strength;;
		case 1: return Base.Quickness;
		case 2: return Base.Toughness;
		case 3: return Base.Willpower;
		}

		return Base.Strength;
	}

	public void AddExperience(Gladiator.Experience type, int amount)
	{
		int stat = (int)type;

		int PrevLevel = GetExperienceLevel(stat);

		switch(stat)
		{
		case 0: Exp.Strength += amount; break;
		case 1: Exp.Quickness += amount; break;
		case 2: Exp.Toughness += amount; break;
		case 3: Exp.Willpower += amount; break;
		}

		int LevelDiff = GetExperienceLevel(stat) - PrevLevel;

		if(LevelDiff > 0)
		{
			IncreaseStat(stat, LevelDiff);
			Debug.Log("Bumping " + type + " by: " + LevelDiff);
		}
	}

	int GetExperienceLevel(int stat)
	{
		switch(stat)
		{
		case 0: return Exp.Strength / 100; break;
		case 1: return Exp.Quickness / 100; break;
		case 2: return Exp.Toughness / 100; break;
		case 3: return Exp.Willpower / 100; break;
		}

		return 0;
	}

	//Generation====================================================================

	private void GenerateBaseStats()
	{
		Base.Strength = 1;
		Base.Quickness = 1;
		Base.Toughness = 1;
		Base.Willpower = 1;

		BonusStats = RandGen.Next(10,21);
				
		if(BonusStats >= 18)
			Traits.Add("Blessed");
		else if(BonusStats <= 12)
			Traits.Add("Misfortuned");
		
		AllocateStats();
		
		Base.HP = 10;
		CurrentHealth = Base.HP;
	}
	
	private void AllocateStats()
	{
		while(BonusStats > 0)
		{
			int s = RandGen.Next(0,4);
			if(GetStat(s) < 8)
			{
				IncreaseStat(s);
				BonusStats--;
			}
		}
	}

	private void GeneratePhysicalTraits()
	{
		//Small Chance to generate a beast
		int CriticalOffset = 20;
		bool Crit = RandGen.Next(0,100) >= 95;

		float rand = DataManager.Instance.Curves.GetRandom(RandGen.Next(0,100000));



		Base.Height = (int)(rand * (float)MaxHeight);
		Base.Height += (Crit ? CriticalOffset : 0);

		if(Base.Height > 50)
			Traits.Add("Giant");

		int WeightModifier = Base.Height/2;

		rand = DataManager.Instance.Curves.GetRandom(RandGen.Next(0,100000));

		Base.Weight = (int)(rand * (float)MaxWeight);
		Base.Weight += WeightModifier;

		int BonusStr = Base.Weight/10;

		//If they're light, increase quickness, else, Increase Strength
		if(BonusStr < 0)
			IncreaseStat(1, Mathf.Abs(BonusStr));
		else
			IncreaseStat(0, Mathf.Abs(BonusStr));
	}

	private void GenerateRacialTraits()
	{		
		SkinColour = RandGen.Next(0, DataManager.Instance.SkinColours.Count);
	}

	private void GenerateName()
	{
		RaceData data = DataManager.Instance.GetRaceData("Roman");

		Name = data.GenerateName(RandGen.Next(0,99999)) + " " + data.GenerateSurname(RandGen.Next(0,99999));
	}



	//==================================================================================
}
