using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterMotor : MonoBehaviour {

	public Animator anim;
	Rigidbody2D rigidbody;


	// Use this for initialization
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(DisplayWindow.bHasPopup)
			return;

		float dirX = Input.GetAxisRaw("Horizontal");
		float dirY = Input.GetAxisRaw("Vertical");

		Vector2 WantMove = new Vector2(dirX, dirY);

		bool bIsWalking = WantMove != Vector2.zero;

		if(bIsWalking)
		{
			anim.SetFloat("DirectionX", dirX);
			anim.SetFloat("DirectionY", dirY);
			//transform.Translate(new Vector3(dirX, dirY, 0) * 3 * Time.deltaTime);
		}

		rigidbody.velocity = WantMove * 200 * Time.deltaTime;
		anim.SetBool("IsWalking", bIsWalking);
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.name == "Exit")
		{
			SceneManager.LoadScene("Map");
		}
	}
}
