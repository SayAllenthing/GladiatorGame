using UnityEngine;
using System.Collections;

public abstract class TimedAction : Action 
{
	protected abstract void preAction();
	protected abstract void HandleAction(float progress);
	protected abstract void postAction();

	public float duration = 1f;
	protected float timePassed = 0;
	public float progress { get { return duration > 0  ? Mathf.Clamp01(timePassed / duration) : 1f; } }
	
	public override bool begin()
	{
		if (base.begin())
		{
			timePassed = 0;
			preAction();
			play();
			return true;
		}
		return false;
	}

	void Update ()
	{
		if (isPlaying)
		{
			timePassed += Time.deltaTime;
			HandleAction(progress);
			if (progress == 1f)
			{
				stop ();
				postAction();
				triggerCompleteEvent();
			}
		}
	}
}
