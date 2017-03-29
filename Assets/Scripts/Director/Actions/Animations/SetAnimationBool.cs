using UnityEngine;
using System.Collections;

public class SetAnimationBool : ImmediateAction {

	public Animator animator;

	public string Parameter;
	public bool Value;

	protected override void HandleAction()
	{
		animator.SetBool(Parameter, Value);
	}
}
