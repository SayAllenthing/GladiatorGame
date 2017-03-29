using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour {

	public RectTransform GladiatorCanvas;

	public GameObject GladiatorPrefab;

	public List<GameObject> Gladiators = new List<GameObject>();
	public List<GameObject> InfoButtons = new List<GameObject>();

	public GameObject InfoPrefab;
	public CanvasGroup InfoPanel;

	public SlaveMarketWindow SlaveInfoWindow;

	GameObject ActiveGladiator = null;

	void Start()
	{
		CreateGladiators();

		GetComponent<MouseClicker>().onClicked += OnClicked;
	}

	void CreateGladiators()
	{
		int num = 5;//Random.Range(1,6);

		for(int i = 0; i < num; i++)
		{
			Gladiator g = new Gladiator();
			g.Init();

			CreateGladiator(g);

			/*
			GameObject obj = RectTransform.Instantiate(GladiatorWindowPrefab) as GameObject;
			obj.GetComponent<SlaveMarketWindow>().SetGladiator(g);
			obj.transform.SetParent(GladiatorCanvas.transform, false);
			obj.transform.position = new Vector3(obj.transform.position.x + 250 * i, obj.transform.position.y, obj.transform.position.z);
			*/
		}
	}

	void CreateGladiator(Gladiator g)
	{
		Vector3 pos = new Vector3(1f + (1.2f * Gladiators.Count), 0.5f, -1);
		
		GameObject glad = GameObject.Instantiate(GladiatorPrefab, pos, Quaternion.identity) as GameObject;
		glad.GetComponent<GladiatorController>().Init(g);

		//CreateInfoButton();

		Gladiators.Add(glad);
	}

	void CreateInfoButton()
	{
		GameObject info = GameObject.Instantiate(InfoPrefab, Vector3.zero, Quaternion.identity) as GameObject;

		//info.transform.parent = InfoPanel.transform;
		info.transform.localScale = new Vector3(1, 1, 1);
		info.transform.localPosition = new Vector3(0 + 93 * Gladiators.Count, 0);

		InfoButtons.Add(info);
	}

	public void SetSlaveWindow(GameObject g)
	{
		int i;
		for(i = 0; i < InfoButtons.Count; i++)
		{
			if(InfoButtons[i] == g)
				break;
		}
		Gladiator glad = Gladiators[i].GetComponent<GladiatorController>().GetGladiator();

		Debug.Log(glad.Name + ": " + glad.PrintTraits());
		SlaveInfoWindow.GetComponent<SlaveMarketWindow>().Init(glad);
	}

	public void OnClicked(GameObject hit)
	{
		if(hit.tag == "Gladiator")
		{			
			SlaveInfoWindow.Init(hit.GetComponent<GladiatorController>().GetGladiator());
			SlaveInfoWindow.Show();
			ActiveGladiator = hit;
		}
	}

	public void OnBuyGladiator()
	{
		GameObject.Destroy(ActiveGladiator);
		ActiveGladiator = null;
	}

}
