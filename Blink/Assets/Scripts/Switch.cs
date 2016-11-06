using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	bool pressed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void buttonPress()
	{
		if (pressed == false) 
		{
			pressed = true;
			Debug.Log (this.gameObject.name + " has been pressed");
		}
	}

	public bool isPressed()
	{
		return pressed;
	}
}
