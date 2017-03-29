using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorFlash : TimedAction 
{
	SpriteRenderer Target;
	Color OriginalColor;
	Color TargetColor;

	public void Init(SpriteRenderer _target, Color c, float _duration = 1)
	{
		Target = _target;
		OriginalColor = Target.color;
		TargetColor = c;
		duration = _duration;
	}
	
	protected override void HandleAction(float progress)
	{
		float prog;
		Color c;

		if(progress < 0.5f)
		{
			prog = progress * 2;
			c = Color.Lerp(OriginalColor, TargetColor, prog);
		}
		else
		{
			prog = (progress - 0.5f) * 2;
			c = Color.Lerp(TargetColor, OriginalColor, prog);
		}

		Target.color = c;
	}

	protected override void preAction()
	{
		Target.color = OriginalColor;
	}

	protected override void postAction()
	{
		Target.color = OriginalColor;
	}
}
