using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data_test : MonoBehaviour {

	private GameObject maph;

	// Use this for initialization
	void Start () {
		
	    maph = GameObject.Find("map_holder");
		maph.transform.GetChild(0).gameObject.GetComponent<map_tiles_v>().num = PlayerPrefs.GetFloat ("cube 0");
		maph.transform.GetChild(1).gameObject.GetComponent<map_tiles_v>().num = PlayerPrefs.GetFloat ("cube 1");
		maph.transform.GetChild(2).gameObject.GetComponent<map_tiles_v>().num = PlayerPrefs.GetFloat ("cube 2");

		for (int i = 0; i < 3; i++) {
			if (maph.transform.GetChild(i).gameObject.GetComponent<map_tiles_v>().num == 1) {
				maph.transform.GetChild (i).gameObject.SetActive(false);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;

		Vector3 detect = (transform.TransformDirection(Vector3.down));
		if (Physics.Raycast (transform.position, detect, out hit, 10.0f)) {
			if (hit.collider.gameObject.name == "cube 0") {
				hit.collider.gameObject.GetComponent<map_tiles_v> ().num = 1;
				PlayerPrefs.SetFloat ("cube 0", hit.collider.gameObject.GetComponent<map_tiles_v>().num);
				hit.collider.gameObject.SetActive (false);
			}
			if (hit.collider.gameObject.name == "cube 1") {
				hit.collider.gameObject.GetComponent<map_tiles_v> ().num = 1;
				PlayerPrefs.SetFloat ("cube 1", hit.collider.gameObject.GetComponent<map_tiles_v>().num);
				hit.collider.gameObject.SetActive (false);
			}
			if (hit.collider.gameObject.name == "cube 2") {
				hit.collider.gameObject.GetComponent<map_tiles_v> ().num = 1;
				PlayerPrefs.SetFloat ("cube 2", hit.collider.gameObject.GetComponent<map_tiles_v>().num);
				hit.collider.gameObject.SetActive (false);
			}
		}
		
	}
}
