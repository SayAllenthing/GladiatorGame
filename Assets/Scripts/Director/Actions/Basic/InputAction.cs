using UnityEngine;
using System.Collections;

public class InputAction : Action
{
	public override bool begin()
	{
		if (base.begin())
		{
			play();
			return true;
		}
		return false;
	}

	void Update()
	{
		if(isPlaying && Input.anyKeyDown)
		{
			stop ();
			triggerCompleteEvent();
		}
	}
}
