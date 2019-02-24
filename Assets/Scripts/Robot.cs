using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Robot : MonoBehaviour {


	public GameObject canvasDialogue;
	[SerializeField]
	private int _happiness ; // o quão feliz ele esta de 0 a 100
	[SerializeField]
	private string _name;

	void Start () {
		Invoke("firstDialogue", 2); //this will happen after 2 seconds

		if (!PlayerPrefs.HasKey ("name")) 
			PlayerPrefs.SetString ("name", "Bob");
			_name = PlayerPrefs.GetString ("name");

		if (!PlayerPrefs.HasKey ("happiness")) {
			_happiness = 100;
			PlayerPrefs.SetInt ("happiness", _happiness);
		} else {
			_happiness = PlayerPrefs.GetInt ("happiness");
		}


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

	public int happiness{
		get { return _happiness;}
		set { _happiness = value;}
	}

	public string name{
		get { return _name;}
		set { _name = value;}
	}

	public void updateHappiness(int i){
		_happiness = _happiness + i;
		if (_happiness > 100)
			_happiness = 100;
	}


}
