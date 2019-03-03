using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Robot : MonoBehaviour {



	[SerializeField]
	private int _happiness ; // o quão feliz ele esta de 0 a 100
	[SerializeField]
	private string _name;
	private int _clickedCount;

	void Start () {
		

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
		GetComponent<Animator> ().SetBool ("jump", gameObject.transform.position.y > -2.4f);

		if (Input.GetMouseButtonUp (0)) {
			Vector2 v = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (v), Vector2.zero);
			Debug.Log("clicou");
			if (hit) {
				//Debug.Log(hit.transform.name);
				if (hit.transform.gameObject.tag == "robot") {
					_clickedCount++;
					if (_clickedCount >= 3) {
						//Debug.Log(hit.transform.name);
						updateHappiness(1);
						_clickedCount = 0;
						GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 1000000));
					}
				}

			}
		}
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
		PlayerPrefs.SetInt ("happiness", _happiness);
		if (_happiness > 100)
			_happiness = 100;
	}


}
