using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleReportPanel : DisplayWindow {

	public Text Name;
	public Text Str;
	public Text Qui;
	public Text Tou;
	public Text Wil;

	public Text HP;

	public Text AvgScr;
	public Text NumTurns;

	int NumRolls;

	public override void Init(Gladiator g)
	{
		base.Init(g);

		Name.text = g.Stats.Name + " (" + g.GetRating() + ")";

		Str.text = "Strength: " + g.BaseStats.Strength;
		Qui.text = "Quickness: " + g.BaseStats.Quickness;
		Tou.text = "Toughness: " + g.BaseStats.Toughness;
		Wil.text = "Willpower: " + g.BaseStats.Willpower;

		HP.text = "Hit Points: " + g.Stats.CurrentHealth;

		AvgScr.text = "Avg Score: 0.0";
		NumTurns.text = "Num Turns: 0";
	}

	public void SetHP(int hp)
	{
		HP.text = "Hit Points: " + hp;
	}

	public float SetScore(float oldScore, float score)
	{
		oldScore *= (float)NumRolls;
		NumRolls++;

		float newScore = (score + oldScore) / (float)NumRolls;

		AvgScr.text = "Avg Score: " + newScore.ToString("0.0");

		return newScore;
	}

	public void SetTurns(int turns)
	{
		NumTurns.text = "Num Turns: " + turns;
	}
}
