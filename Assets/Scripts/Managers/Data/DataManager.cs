using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DataManager : MonoBehaviour 
{
	public List<Color> SkinColours = new List<Color>();

	RaceData Roman;

	public static DataManager Instance;

	public RandomCurve Curves;

	// Use this for initialization
	void Awake () 
	{
		if(Instance == null)
		{
			Debug.Log("Creating new Data instance");
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
			Load();
		}
		else
		{
			DestroyImmediate(this.gameObject);
			return;
		}
	}

	public void Load()
	{
		Roman = new RaceData();
		Roman.LoadNames("Text/names_Roman");

		LoadSkinColours();
	}

	public RaceData GetRaceData(string race)
	{
		return Roman;
	}

	private void LoadSkinColours()
	{
		TextAsset content = Resources.Load("Text/SkinColours") as TextAsset;
		string[] textFile = content.text.Split("\n"[0]);

		foreach(string line in textFile)
		{
			SkinColours.Add(Helper.HexToColor(line));
		}
	}

	public void SaveFile()
	{
		PlayerPrefs.DeleteAll();

		//Player
		PlayerPrefs.SetInt("Denari", Player.Instance.Denarii);

		//Gladiators
		//=============================================================================
		List<Gladiator> glads = Player.Instance.Gladiators;

		PlayerPrefs.SetInt("NumGlads", glads.Count);

		for(int i = 0; i < glads.Count; i++)
		{
			string gladNum = "Glad" + i;
			PlayerPrefs.SetInt(gladNum + "Seed", glads[i].Stats.Seed);
			PlayerPrefs.SetInt(gladNum + "Health", glads[i].Stats.CurrentHealth);
		}
		//=============================================================================

		PlayerPrefs.Save();
	}

	public void LoadFile()
	{		
		//Player
		Player.Instance.Denarii = PlayerPrefs.GetInt("Denari");

		//Gladiators
		//=============================================================================
		int numGlads = PlayerPrefs.GetInt("NumGlads");

		for(int i = 0; i < numGlads; i++)
		{
			string gladNum = "Glad" + i;
			int seed = PlayerPrefs.GetInt(gladNum + "Seed");

			Gladiator g = new Gladiator();
			g.Init(seed);

			g.Stats.CurrentHealth = PlayerPrefs.GetInt(gladNum + "Health");

			g.Stats.AddExperience(Gladiator.Experience.QUICKNESS, 789);

			Player.Instance.AddGladiator(g);
		}
		//=============================================================================
	}
}
