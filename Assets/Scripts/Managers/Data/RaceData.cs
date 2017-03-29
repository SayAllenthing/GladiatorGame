using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class RaceData 
{

	public List<string> Prefixes = new List<string>();
	public List<string> Suffixes = new List<string>();

	public List<string> Surnames = new List<string>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadNames(string filename)
	{
		TextAsset content = Resources.Load(filename) as TextAsset;

		string[] textFile = content.text.Split("\n"[0]);

		string currentTask = "";


		foreach(string l in textFile)
		{
			string line = l.Remove(l.Length-1);

			if(line == "-")
				continue;

			if(line == "Prefix" || line == "Suffix" || line == "Surname")
			{
				currentTask = line;	
				continue;
			}

			

			if(currentTask == "Prefix")
				Prefixes.Add(line);
			else if(currentTask == "Suffix")
				Suffixes.Add(line);
			else if(currentTask == "Surname")
				Surnames.Add(line);			
		}
	}

	public string GenerateName(int seed)
	{
		System.Random rand = new System.Random(seed);

		int pre = rand.Next(0, Prefixes.Count);
		int suf = rand.Next(0, Suffixes.Count);

		string name = Prefixes[pre] + Suffixes[suf];

		return name;
	}

	public string GenerateSurname(int seed)
	{
		System.Random rand = new System.Random(seed);

		int sur = rand.Next(0, Surnames.Count);
		string name = Surnames[sur];

		return name;
	}
}
