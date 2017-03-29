using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleDirector : MonoBehaviour 
{
	//Battle Director allows objects to call specific actions
	//as opposed to manually set up cutscenes/action groups

	//Battle Action Classes
	public GameObject actions;

	public delegate void CompleteDelegate();
	public event CompleteDelegate onComplete;

	void PlayAction(Action act)
	{
		act.onComplete += OnActionComplete;
		act.begin();
	}

	void OnActionComplete(Action act)
	{
		act.onComplete -= OnActionComplete;

		if (onComplete != null)
			onComplete();
	}

	//Actions=======================================

	public void FlashColor(SpriteRenderer r, Color c, float duration)
	{
		ColorFlash act = actions.GetComponent<ColorFlash>();
		act.Init(r,c,duration);
		PlayAction(act);
	}

	public void MovePawnToPosition(Transform p1, Vector3 dest, float dur, float apex)
	{				
		MoveTransformWithApex act = actions.GetComponent<MoveTransformWithApex>();
		act.Init(p1, dest, dur, apex);
		PlayAction(act);
	}
}
