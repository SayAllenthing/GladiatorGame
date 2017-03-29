using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public float MinX = 0;
	public float MaxX = 50;

	public Transform Target;

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;

	private Camera camera;

	void Start()
	{
		camera = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () 
	{
		
		if(Target == null)
			return;

		Vector3 targetPos = Target.position;

		if(targetPos.x > MinX && targetPos.x < MaxX)
		{
			Vector3 pos = transform.position;
			pos.x = targetPos.x;
			transform.position = pos;
		}

		/*
		float wantX = Target.position.x;

		Vector3 pos = transform.position;
		float x = Mathf.Lerp(pos.x, wantX, 2 * Time.deltaTime);


		if(x > MinX && x < MaxX)
		{
			pos.x = x;
			transform.position = pos;
		}


		if (Target)
		{			
			Vector3 point = camera.WorldToViewportPoint(Target.position);
			Vector3 delta = Target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		*/
	}

	public void SetTarget(Transform t)
	{
		Target = t;
	}
}
