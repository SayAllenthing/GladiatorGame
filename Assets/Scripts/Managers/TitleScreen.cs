using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	public CanvasGroup LoadMenu;

	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.HasKey("NumGlads"))
		{
			LoadMenu.alpha = 1;
			LoadMenu.interactable = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
		Application.LoadLevel("Map");
	}

	public void LoadGame()
	{
		DataManager.Instance.LoadFile();
		Application.LoadLevel("Map");
	}
}
