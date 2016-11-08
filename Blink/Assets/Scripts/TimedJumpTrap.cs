using UnityEngine;
using System.Collections;

public class TimedJumpTrap : MonoBehaviour {

	public GameObject wall;

	void Start () {
		StartCoroutine (toggleDeathWall());
		
	}
		
	bool isWallActive = false;

	IEnumerator toggleDeathWall() {
		for(;;) {

			wall.SetActive( isWallActive );
			isWallActive = !isWallActive;
//			Debug.Log ("death is" + isWallActive);
			yield return new WaitForSeconds(1f);
		}
	}
}
