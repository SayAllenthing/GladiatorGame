using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject PlayerPrefab;
	public PlayerCamera camera;

	// Use this for initialization
	void Start () 
	{
		GameObject p = GameObject.Instantiate(PlayerPrefab, transform.position, Quaternion.identity) as GameObject;
		camera.SetTarget(p.transform);
	}

}
