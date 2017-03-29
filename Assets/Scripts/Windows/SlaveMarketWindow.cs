using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlaveMarketWindow : DisplayWindow {


	public Text TextName;
	/*public UILabel TextRace;

	public UILabel TextStrength;
	public UILabel TextQuickness;
	public UILabel TextToughness;
	public UILabel TextWillpower;
	*/
	public Text BuyButton;

	public MarketManager market;

	int Price = 0;

	public override void Init(Gladiator g)
	{
		base.Init(g);
	}

	public void SetGladiator(Gladiator g)
	{
		gladiator = g;
		Refresh();
	}

	protected override void Refresh()
	{
		TextName.text = gladiator.Name;

		int basePrice = (gladiator.GetRating() * 2);
		float curveValue = 1f + DataManager.Instance.Curves.GetAscending(basePrice, 50);
		int price = (int)(basePrice * curveValue);

		Debug.Log("b " + basePrice + " c " + curveValue);

		BuyButton.text = price.ToString();

		Price = price;
	}

	public void OnBuyPressed()
	{
		if(Player.Instance.OwnsGladiator(gladiator))
			return;

		if(Player.Instance.Denarii < Price)
			return;

		Player.Instance.Denarii -= Price;

		Player.Instance.AddGladiator(gladiator);
		Hide();

		market.OnBuyGladiator();
	}

}
