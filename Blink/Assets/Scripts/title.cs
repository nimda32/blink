using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class title : MonoBehaviour {

	public Button start; // assign in the editor


	void Start() {
		start.onClick.AddListener(() => { start_onClick(); });
	}

	void start_onClick(){
		SceneManager.LoadScene("Level1",LoadSceneMode.Single);
		Debug.Log ("Move to level 1");
	}

}
