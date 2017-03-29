using UnityEngine;
using System.Collections;

public class MarketButtonDelegate : MonoBehaviour {

	void OnClick()
	{
		GameObject.Find("MarketManager").GetComponent<MarketManager>().SetSlaveWindow(this.gameObject);
	}
}
