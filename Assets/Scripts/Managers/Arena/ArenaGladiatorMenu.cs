using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using System.Collections.Generic;

public class ArenaGladiatorMenu : MonoBehaviour {

	public ArenaManager arenaManager;

	public CanvasGroup Panel;
	public CanvasGroup Container;

	public GameObject ButtonPrefab;

	// Use this for initialization
	void Start () 
	{
		List<Gladiator> glads = Player.Instance.Gladiators;

		for(int i = 0; i < glads.Count; i++)
		{
			GameObject g = GameObject.Instantiate(ButtonPrefab, Container.transform) as GameObject;
			g.GetComponent<ArenaGladiatorButton>().SetName(glads[i].Name);
			int index = i;

			g.GetComponent<Button>().onClick.AddListener(delegate { this.SelectGladiator(index); });
		}
	}
	
	public void SelectGladiator(int index)
	{
		Panel.alpha = 0;
		Gladiator g = Player.Instance.Gladiators[index];

		arenaManager.SelectGladiator(g);
	}
}
