using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class battlecanvas : MonoBehaviour {

	public static battlecanvas instance;
	public movement moveScript;

	// Use this for initialization
	void Awake () {
//		moveScript = GameObject.Find ("Character").transform.GetComponent<movement>();
		Invoke("Characterscript",3);
		if (instance != null) {
			Destroy (gameObject);
		} else {

			instance = this;
		}
		instance.transform.GetChild (9).transform.position = new Vector3(0,900,0);
		instance.transform.GetChild (10).transform.position = new Vector3(0,900,0);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.I)) {
			Open();
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			OpenM();
		}
	}

	public void Close(){
		moveScript.CanControl = true;
		Time.timeScale = 1;
		instance.transform.GetChild (9).transform.position = new Vector3(0,900,0);
	}

	public void Open(){
		moveScript.CanControl = false;
		Time.timeScale = 0;
		instance.transform.GetChild (9).transform.position = new Vector3(0,0,0);
	}

	public void CloseM(){
		moveScript.CanControl = true;
		Time.timeScale = 1;
		instance.transform.GetChild (10).transform.position = new Vector3(0,900,0);
	}

	public void OpenM(){
		moveScript.CanControl = false;
		Time.timeScale = 0;
		instance.transform.GetChild (10).transform.position = new Vector3(0,0,0);
	}

	public void OpenGrid(){
		instance.transform.GetChild (12).transform.position = new Vector3(0,0,0);
	}
	public void CloseGrid(){
		instance.transform.GetChild (12).transform.position = new Vector3(0,900,0);
	}
	public void Characterscript(){
		moveScript = GameObject.Find ("Character").transform.GetComponent<movement>();
	}
}
