using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int speed = 10;

	public Animator animator; // movement animation object

	private SpriteRenderer sr;

	private int jumpHeight = 620;
	int direction = 0; //0-right, 1-left
	Vector3 dir = new Vector3(1, 0, 0);
	Vector3 teleDist = new Vector3 (5, 0, 0);
	Rigidbody r;


	// Use this for initialization
	void Start () 
	{
		r = GetComponent<Rigidbody>();
		sr = GetComponent<SpriteRenderer>();
	}

	bool isGrounded()
	{
		return (r.velocity.y >= -0.01f && r.velocity.y <= 0.01f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		animator.SetBool ("walking", false);

		//Left-Right Movement
		if(Input.GetKey(KeyCode.A)) {
			dir += transform.right * Time.deltaTime * -speed;
			direction = 1;
			animator.SetBool ("walking", true);
			sr.flipX = true;

		}
		else if(Input.GetKey(KeyCode.D)) {
			dir += transform.right * Time.deltaTime * speed;
			direction = 0;
			animator.SetBool ("walking", true);
			sr.flipX = false;

		}
		r.MovePosition (transform.position + dir);
		dir = new Vector3 (0, 0, 0);

		//Jumping
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			if (isGrounded ())
			{
				r.AddForce(new Vector3(0, jumpHeight, 0));
			}
		}

		//Teleporting
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			RaycastHit hit;
			//teleport right
			if (direction == 0)
			{
				//Check if there's anything in front of you that you might get stuck in
				if (Physics.Raycast(transform.position, Vector3.right, out hit, 5.0f))
				{
					//if there is, stop in front of it
					r.MovePosition (transform.position + new Vector3(hit.distance, 0, 0));
				}
				else
				{
					//otherwise teleport normally
					r.MovePosition (transform.position + teleDist);
				}
			}
			//teleport left
			else if (direction == 1)
			{
				//Check if there's anything in front of you that you might get stuck in
				if (Physics.Raycast(transform.position, Vector3.left, out hit, 5.0f))
				{
					//if there is, stop in front of it
					r.MovePosition (transform.position - new Vector3(hit.distance, 0, 0));
				}
				else
				{
					//otherwise teleport normally
					r.MovePosition (transform.position - teleDist);
				}
			}
		}
				
	}
}
