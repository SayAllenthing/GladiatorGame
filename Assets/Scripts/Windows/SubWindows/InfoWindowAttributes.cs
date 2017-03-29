using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoWindowAttributes : SubWindow
{
	public Text Strength;	
	public Text Quickness;	
	public Text Toughness;	
	public Text Willpower;
	
	public override void Init(Gladiator g)
	{
		Strength.text = "Strength: " + g.BaseStats.Strength.ToString();
		Quickness.text = "Quickness: " + g.BaseStats.Quickness.ToString();
		Toughness.text = "Toughness: " + g.BaseStats.Toughness.ToString();
		Willpower.text = "Willpower: " + g.BaseStats.Willpower.ToString();
	}

}
