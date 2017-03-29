using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayWindow : MonoBehaviour {

	public static bool bHasPopup = false;

	bool bIsShowing = false;
	bool bIsSwitching = false;

	protected Gladiator gladiator;

	CanvasGroup group;

	// Use this for initialization
	void Start () 
	{
		group = GetComponent<CanvasGroup>();
	}
	
	public virtual void Show()
	{		
		Refresh();
		bIsShowing = true;
		group.alpha = 1;

		bHasPopup = true;
	}

	public virtual void Hide()
	{
		bIsShowing = false;
		group.alpha = 0;

		bHasPopup = false;
	}

	public virtual void Init(Gladiator g)
	{
		if(bIsShowing && gladiator != null && gladiator == g)
			return;

		gladiator = g;
		if(bIsShowing)
		{
			Switch();
		}
		else
		{
			Show();
		}
	}

	void Switch()
	{
		bIsSwitching = true;
		Hide();
	}

	protected virtual void Refresh()
	{

	}

	public void OnTweenComplete()
	{
		if(bIsSwitching)
		{
			bIsSwitching = false;
			Init(gladiator);
		}
	}
}
