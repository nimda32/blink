using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WallSmash : MonoBehaviour {

	public GameObject player;

	private int direction = -1; //-1:down, 1:up
	float upDelay = 1.5f;
	float downDelay = 0.5f;
	private float delay = 2.0f;
	int speed = 10;
	int upSpeed = 3;
	int downSpeed = 10;
	Vector3 initialPos;
	Vector3 dir;
	bool canMove = true;
	Rigidbody r;

	Vector3 playersOriginalPosition;

	// Use this for initialization
	void Start () {
		playersOriginalPosition = player.transform.position;
		initialPos = gameObject.transform.position;
		r = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (delay > 0) 
		{
			delay -= Time.deltaTime;
		}
		if (delay <= 0) 
		{
			dir += transform.up * speed * Time.deltaTime * direction;
		}
		//r.MovePosition (transform.position + dir);
		transform.position += dir;
		dir = new Vector3 (0, 0, 0);
		if (direction == 1 && transform.position.y > initialPos.y) 
		{
			changeDirection ();
		}
	
	}
	void changeDirection()
	{
		if (direction == 1) 
		{
			delay = upDelay;
			speed = downSpeed;
		} 
		else 
		{
			delay = downDelay;
			speed = upSpeed;
		}
		direction *= -1;
	}
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Equals ("Player")) 
		{
			if (direction == -1 && delay <= 0) 
			{
				//teleports player to starting position
				player.transform.position = playersOriginalPosition;
			}
		} 
		else 
		{
			changeDirection();
		}
	}
}
