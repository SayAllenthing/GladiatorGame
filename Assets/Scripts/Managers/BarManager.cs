using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarManager : MonoBehaviour {

	public static BarManager Instance;

	public Text DenariiText;

	// Use this for initialization
	void Awake () 
	{
		if(Instance == null)
		{			
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			DestroyImmediate(this.gameObject);
			return;
		}
	}
	
	public void Refresh()
	{
		Player p = Player.Instance;
		if(p == null)
			return;

		DenariiText.text = "Denari " + Player.Instance.Denarii;
	}

	public void OnBackButtonPressed()
	{
		if(Application.loadedLevelName == "Map")
		{
			Application.LoadLevel("TitleScreen");
		}
		else if(Application.loadedLevelName != "TitleScreen")
		{
			Application.LoadLevel("Map");
		}

	}
}
