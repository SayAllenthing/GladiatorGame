using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		DataManager.Instance.SaveFile();
		BarManager.Instance.Refresh();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void QuitGame()
	{
		Application.LoadLevel("TitleScreen");
	}

	public void GoToColosseum()
	{
		Application.LoadLevel("TestScene");
	}

	public void GoToLudus()
	{
		Application.LoadLevel("Ludus");
	}

	public void GoToMarket()
	{
		Application.LoadLevel("Market");
	}

	public void GoToPit()
	{

	}
}
