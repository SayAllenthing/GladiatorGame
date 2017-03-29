using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {

	protected bool playing = false;
	public bool isPlaying { get { return playing; } }
	protected bool paused = false;
	public bool isPaused { get { return paused; } }

	public virtual bool begin()
	{
		if (this.isPlaying == false)
		{
			return true;
		}
		return false;
	}

	protected void play()
	{
		if (!isPlaying)
			playing = true;
	}

	protected void stop()
	{
		playing = false;
	}

	protected void triggerCompleteEvent()
	{
		if (onComplete != null)
			onComplete(this);
	}

	public delegate void CompleteDelegate(Action sender);
	public event CompleteDelegate onComplete;
}
