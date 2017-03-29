using UnityEngine;
using System.Collections;

public abstract class ImmediateAction : Action 
{
	public override bool begin()
	{
		if(base.begin())
		{
			HandleAction();
			triggerCompleteEvent();
			return true;
		}

		return false;
	}

	protected abstract void HandleAction();
}
