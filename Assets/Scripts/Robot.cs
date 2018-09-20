using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Robot : MonoBehaviour {


	public GameObject canvasDialogue;

	private int _happiness; // o quão feliz ele esta de 0 a 100
	private string _name;

	void Start () {
		Invoke("firstDialogue", 2); //this will happen after 2 seconds

		if (!PlayerPrefs.HasKey ("name")) {
			PlayerPrefs.SetString ("name", "Pet");
			_name = PlayerPrefs.GetString ("name");
		}
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Animator> ().SetBool ("jump", gameObject.transform.position.y > -1.4f);
		if (!PlayerPrefs.HasKey ("_happiness")) {
			_happiness = 100;
			PlayerPrefs.SetInt ("_happiness", _happiness);
		}
		if (Input.GetMouseButtonUp (0)) {
			canvasDialogue.SetActive (false);
		}
	}

	void firstDialogue(){
		canvasDialogue.SetActive (!canvasDialogue.activeInHierarchy);
	}

	public int happiness{
		get { return _happiness;}
		set { _happiness = value;}
	}



}
