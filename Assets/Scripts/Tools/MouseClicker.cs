using UnityEngine;
using System.Collections;

public class MouseClicker : MonoBehaviour {

	public enum WorldSpace
	{
		WORLDSPACE_2D,
		WORLDSPACE_3D
	}

	public WorldSpace worldSpace;

	void Update() 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			if(worldSpace == WorldSpace.WORLDSPACE_2D)
				CastRay();
			else if(worldSpace == WorldSpace.WORLDSPACE_3D)
				CastRay3D();
		}
	}
	
	void CastRay() 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100);
		if (hit) 
		{
			if (onClicked != null)
				onClicked(hit.collider.gameObject);
		}
	}

	void CastRay3D() 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100)) 
		{
			if (onClicked != null)
				onClicked(hit.collider.gameObject);
		}
	}

	public delegate void ClickDelegate(GameObject hit);
	public event ClickDelegate onClicked;
}
