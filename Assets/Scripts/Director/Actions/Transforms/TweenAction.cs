using UnityEngine;
using System.Collections;

public class TweenAction : TimedAction 
{
	public Transform target;
	public Transform destination;

	Vector3 initialPosition;
	Quaternion initialRotation;

	protected override void preAction ()
	{
		initialPosition = target.position;
		initialRotation = target.rotation;
	}

	protected override void HandleAction (float progress)
	{
		target.position = Vector3.Lerp(initialPosition, destination.position, progress);
		target.rotation = Quaternion.Lerp(initialRotation, destination.rotation, progress);
	}

	protected override void postAction ()
	{
	}
}
