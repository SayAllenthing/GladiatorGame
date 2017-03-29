using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoWindowGeneral : SubWindow 
{
	public Text Race;

	public Text Profession;

	public Text Health;

	public Text Height;
	public Text Weight;

	public override void Init(Gladiator g)
	{
		Race.text = "Roman";
		Profession.text = "Centurion";

		Health.text = g.Stats.CurrentHealth + "/" + g.BaseStats.HP;

		Height.text = g.Stats.GetHeight().ToString() + "cm";
		Weight.text = g.Stats.GetWeight().ToString() + "kg";
	}

}
