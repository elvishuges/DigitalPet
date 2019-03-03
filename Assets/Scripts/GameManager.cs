
﻿	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using System;
	
namespace Assets.SimpleAndroidNotifications{
	public class GameManager : MonoBehaviour {

		public GameObject happinessText;
		public GameObject nameText;
		public GameObject taskPanel;
		public GameObject nameTaskInputField;
		public GameObject timeMinutesTaskInputField;

		public GameObject listPanel;

		[SerializeField] Transform  gridElemets;
		[SerializeField] GameObject buttonPrefabs;
		public GameObject robot;
		public GameObject [] robotList;


		public GameObject task;
		List<GameObject> taskList;	     


		// Use this for initialization
		void Start () {
			taskList = new List<GameObject>();
			welcomeNotification ();
			Debug.Log ("felicidade do pet :"+happinessText.GetComponent<Text> ().text );
			creatRobot (0);

			}
		
		// Update is called once per frame
		void Update () {
			//robot.GetComponent<Robot> ().updateHappiness (-2);
			happinessText.GetComponent<Text> ().text = "" + robot.GetComponent<Robot> ().happiness;	
			nameText.GetComponent<Text> ().text = robot.GetComponent<Robot> ().name;
			if (Input.GetKeyUp (KeyCode.Space)) {
				creatRobot (1);
			}
			if (Input.GetKeyUp (KeyCode.D)) {
				creatRobot (2);
			}
		}

		public void buttonBehavior(int i){
			robot.GetComponent<Robot> ().updateHappiness (-2);
			switch (i)
			{
			case 0:
				toggle (listPanel);
				taskPanel.SetActive (!taskPanel.activeInHierarchy);
				break;
			case 1:
				break;
			case 2:
				toggle (taskPanel);
				listPanel.gameObject.SetActive(!listPanel.gameObject.activeInHierarchy);
				print ("Botao 2 clicado");
				break;
			case 5:
				print ("Botao 5 clicado");
				Application.Quit();
			break;			

			}
		}

		public void toggle(GameObject g){
			if (g.activeInHierarchy)
				g.SetActive (false);
		}
		 


		public void storeTask(){		
			toggle (taskPanel);
			Debug.Log ("Store clicked");
			string name = nameTaskInputField.GetComponent<InputField> ().text;
			nameTaskInputField.GetComponent<InputField> ().text = null;
			int timeMinutes = int.Parse(timeMinutesTaskInputField.GetComponent<InputField> ().text);
			timeMinutesTaskInputField.GetComponent<InputField> ().text = null;
			Debug.Log (name);
           //verificar se o name não é null

			int timeconverted = convertPassedTimeToSeconds (timeMinutes);		   
			
			task = Instantiate(task) as GameObject;

			task.GetComponent<Task> ()._name = name;
			task.GetComponent<Task> ()._timeInSeconds = timeconverted;
			task.GetComponent<Task> ()._id = UnityEngine.Random.Range (0, int.MaxValue);


			taskList.Add (task);

			//chamar metodo para povoar o panel de lista
			addTaskListPanel(task);
									
		}	   

		public int convertPassedTimeToSeconds(int minutes){			
			return minutes * 60 ;
		}

		public void addTaskListPanel(GameObject task){

			Vector3 vector3;
			vector3.x = (float) 1.0000; 
			vector3.y = (float) 1.0000;
			vector3.z = 1;

			Vector2 vector2;
			vector2.x = (float) 698.8; 
			vector2.y = (float) 95.644;

			Debug.Log (task.GetComponent<Task> ()._name);
			GameObject button = (GameObject) Instantiate (buttonPrefabs);
			button.GetComponentInChildren< RectTransform> ().localScale = vector3;
			button.GetComponentInChildren< RectTransform> ().sizeDelta = vector2;
		    button.GetComponentInChildren<Text>().text= task.GetComponent<Task> ()._name;
			button.transform.parent = gridElemets;


		}

		public void creatRobot(int i){
			if (robot) {
				Destroy (robot);
				robot = Instantiate (robotList [i], Vector3.zero, Quaternion.identity) as GameObject;
			}
			//toggle (robotpanel);
			PlayerPrefs.SetInt ("look", i);
		}


		public void welcomeNotification()
		{
			var notificationParams = new NotificationParams
			{
				Id = UnityEngine.Random.Range(0, int.MaxValue),
				Delay = TimeSpan.FromSeconds(10),
				Title = "Seja Bem-Vindo !!",
				Message = "Cuide do Seu Pet, e Cuide de Você !!",
				Ticker = "Ticker",
				Sound = true,
				Vibrate = true,
				Light = true,
				SmallIcon = NotificationIcon.Heart,
				SmallIconColor = new Color(0, 0.5f, 0),
				LargeIcon = "app_icon"
			};

			NotificationManager.SendCustom(notificationParams);
		}

	}

}	