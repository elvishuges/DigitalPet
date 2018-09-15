using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
	

	public GameObject flashText;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("flashTheText",.5f,.5f);
	} 
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0))
			SceneManager.LoadScene ("Game");
	}

	void flashTheText(){
		if (this.flashText.activeInHierarchy) 
			this.flashText.SetActive(false);		
		else 
			this.flashText.SetActive(true);

	}
}
