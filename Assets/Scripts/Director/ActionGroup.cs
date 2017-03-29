using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionGroup : MonoBehaviour {

	public List<Action> actions;
	List<Action> currentActions;

	public bool inProgress;

	public void AppendAction(Action action)
	{
		beginAction(action);
	}

	public bool begin(Director director)
	{
		if (currentActions == null)
			currentActions = new List<Action>(actions.Count);
		else
			currentActions.Clear();
		
		for (int i = 0; i < actions.Count; i++)
		{
			if (actions[i] != null)
			{
				beginAction(actions[i]);
			}
		}

		return true;
	}

	void beginAction(Action action)
	{
		currentActions.Add(action);
		action.onComplete += actionComplete;
		bool result = action.begin();
		if (result == false)
		{
			currentActions.Remove(action);
			action.onComplete -= actionComplete;
		}
	}

	//Event
	void actionComplete(Action sender)
	{
		if (currentActions.Contains(sender))
		{
			currentActions.Remove(sender);
			sender.onComplete -= actionComplete;
			
			if (currentActions.Count == 0)
				complete();
		}
	}

	void complete()
	{
		inProgress = false;

		if (onComplete != null) 
			onComplete();
	}

	public delegate void CompleteDelegate();
	public event CompleteDelegate onComplete;
}
