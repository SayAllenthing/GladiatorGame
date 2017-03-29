using UnityEngine;
using System.Collections;

public class MoveTransformWithApex : TimedAction {

	Transform target;
	Vector3 destination;
	
	Vector3 initialPosition;
	float apex;

	float prevProg;

	public void Init(Transform _target, Vector3 _destination, float _duration = 1, float _apex = 0)
	{
		target = _target;
		destination = _destination;
		apex = _apex;
		duration = _duration;
	}
	
	protected override void preAction ()
	{
		initialPosition = target.position;
	}
	
	protected override void HandleAction (float progress)
	{
		if(prevProg < 0.5f && progress >= 0.5f)
		{
			initialPosition = target.position;
		}

		float prog;
		if(progress < 0.5f)
		{
			prog = progress * 2;
			Vector3 dest = destination - (destination - initialPosition)/2;
			target.position = Vector3.Lerp(initialPosition, dest + new Vector3(0,apex,0), prog);
		}
		else
		{
			prog = (progress - 0.5f) * 2;
			target.position = Vector3.Lerp(initialPosition, destination, prog);
		}

		prevProg = progress;
	}

	protected override void postAction ()
	{
	}
}
