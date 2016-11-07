using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	bool pressed = false;

	private Animator anim; // animation object

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void buttonPress()
	{
		if (pressed == false) 
		{
			anim.SetBool ("flipped", true);
			pressed = true;
			Debug.Log (this.gameObject.name + " has been pressed");

		}
	}

	public bool isPressed()
	{
		return pressed;
	}
}
