using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Director : MonoBehaviour {

	public delegate void CompleteDelegate();
	public event CompleteDelegate onComplete;

	public ActionGroup[] actionGroups;
	List<ActionGroup> actionGroupQueue;

	public ActionGroup currentActionGroup { get { return actionGroupQueue.Count > 0 ? actionGroupQueue[0] : null; } }

	public Transform character;

	void Awake ()
	{
		actionGroupQueue = new List<ActionGroup>(actionGroups.Length);
	}

	void Start ()
	{
		
	}

	public void PlayActionByName(string name)
	{
		GameObject.Find(name).GetComponent<Action>().begin();
	}

	void Update()
	{

	}

	public void play()
	{
		if (actionGroups.Length > 0)
		{
			for (int i = 0; i < actionGroups.Length; i++)
				actionGroupQueue.Add(actionGroups[i]);
			
			beginCurrentActionGroup();
		}
	}
	
	void beginCurrentActionGroup()
	{
		currentActionGroup.onComplete += currentActionGroupComplete;
		bool result = currentActionGroup.begin(this);
		if (result == false)
		{
			currentActionGroupComplete();
		}
	}
	
	void currentActionGroupComplete()
	{		
		currentActionGroup.onComplete -= currentActionGroupComplete;
		actionGroupQueue.RemoveAt(0);

		if (currentActionGroup != null)
		{
			beginCurrentActionGroup();
		}
		else
		{			
			if (onComplete != null)
				onComplete();
		}
	}
}
