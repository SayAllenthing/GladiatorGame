using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SubWindow : MonoBehaviour 
{
	CanvasGroup Window;


	// Use this for initialization
	void Start () 
	{
		Window = GetComponent<CanvasGroup>();
	}

	public virtual void Init(Gladiator g)
	{

	}

	public virtual void Show()
	{
		Window.alpha = 1;
	}

	public virtual void Hide()
	{
		Window.alpha = 0;
	}

}
