using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public int direction = 0; //0-right, 1-left
	public int speed = 10;
	private int jumpHeight = 620;

	public Vector3 initialposition;




	bool door1 = false;

	public Animator animator; // movement animation object
	private SpriteRenderer sr;

	Vector3 dir = new Vector3(1, 0, 0);
	Vector3 teleDist = new Vector3 (5, 0, 0);
	Rigidbody r;


	public AudioSource source;
	public AudioSource[] list;

	public AudioClip walkingSound;
	public AudioClip jumpingSound;
	public AudioClip teleportSound;
	public AudioClip deathSound;

	Vector3 originalPos;
	// Use this for initialization
	void Start () 
	{

		originalPos = transform.position;

		source = GetComponent<AudioSource>();
		r = GetComponent<Rigidbody>();
		sr = GetComponent<SpriteRenderer>();
		initialposition = transform.position;

		//		list = new AudioClip[]{(AudioClip)Resources.Load ("Sounds/footstep.wav"),
		//			(AudioClip)Resources.Load ("Sounds/chimes.wav"),
		//			(AudioClip)Resources.Load ("Sounds/boing.wav")
		//		};
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
			if (isGrounded())
			{
				r.AddForce(new Vector3(0, jumpHeight, 0));
				source.clip = jumpingSound;
				source.PlayOneShot(jumpingSound, 1F);
			}
		}

		//Teleporting
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			source.time = 1.2f;
			source.clip = teleportSound;
			source.Play();

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

	void OnCollisionEnter (Collision col)
	{
		//Used tags so we can easily add in new doors and switches
		if (col.gameObject.CompareTag ("Switch")) {
			Switch s;
			s = col.gameObject.GetComponent<Switch> ();
			s.buttonPress (); //switch is pressed
				


		} else if (col.gameObject.CompareTag ("Door")) {
			Door d;
			d = col.gameObject.GetComponent<Door> ();
			d.checkSwitches (); //check if all switches have been pressed and update door lock state

			if (d.isUnlocked ()) {
				//move to next level
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

			}
		} else if (col.gameObject.CompareTag ("DeathPit")) {
			transform.position = initialposition;
			source.clip = deathSound;
			source.Play();
		}
	}
}
