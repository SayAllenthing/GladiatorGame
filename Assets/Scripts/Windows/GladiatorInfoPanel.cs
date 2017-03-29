using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GladiatorInfoPanel : DisplayWindow {

	public SubWindow GeneralWindow;
	public SubWindow AttributesWindow;
	public SubWindow StatsWindow;

	public Text Name;

	public override void Init(Gladiator g)
	{
		base.Init(g);

		Name.text = g.Name;

		GeneralWindow.Init(g);
		AttributesWindow.Init(g);

		ShowGeneral();
	}

	public void ShowGeneral()
	{
		AttributesWindow.Hide();

		GeneralWindow.Show();
	}

	public void ShowAttributes()
	{
		GeneralWindow.Hide();

		AttributesWindow.Show();
	}

	public void ShowStats()
	{

	}
}
