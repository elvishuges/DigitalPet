using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Robot : MonoBehaviour {

	public GameObject canvasDialogue;

	// Use this for initialization
	void Start () {
		
		Invoke("firstDialogue", 2); //this will happen after 2 seconds
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Animator> ().SetBool ("jump", gameObject.transform.position.y > -1.4f);

		if (Input.GetMouseButtonUp (0)) {
			canvasDialogue.SetActive (false);
		}
	}

	void firstDialogue(){
		canvasDialogue.SetActive (!canvasDialogue.activeInHierarchy);
	}



}
