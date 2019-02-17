<<<<<<< HEAD
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
		public GameObject exitPanel;
		public GameObject nameTaskInputField;
		public GameObject timeHoursTaskInputField;
		public GameObject timeMinutesTaskInputField;

		public GameObject listPanel;

		[SerializeField] Transform  gridElemets;
		[SerializeField]  GameObject buttonPrefabs;
		public GameObject robot;


		public GameObject task;
		List<GameObject> taskList;	     


		// Use this for initialization
		void Start () {
			taskList = new List<GameObject>();
			welcomeNotification ();
			Debug.Log ("felicidade do"+happinessText.GetComponent<Text> ().text );
			}
		
		// Update is called once per frame
		void Update () {
			happinessText.GetComponent<Text> ().text = "" + robot.GetComponent<Robot> ().happiness;	
			nameText.GetComponent<Text> ().text = robot.GetComponent<Robot> ().name;
		}

		public void buttonBehavior(int i){
			switch (i)
			{
			case 0:
				toggle (listPanel);
				toggle (exitPanel);
				taskPanel.SetActive (!taskPanel.activeInHierarchy);
				break;
			case 1:
				break;
			case 2:
				toggle (taskPanel);
				toggle (exitPanel);
				listPanel.gameObject.SetActive(!listPanel.gameObject.activeInHierarchy);
				print ("Botao 2 clicado");
				break;
			case 5:
			    print ("Botao 5 clicado");
				toggle (listPanel);
				toggle (taskPanel);
				exitPanel.gameObject.SetActive(!exitPanel.gameObject.activeInHierarchy);
				break;
			case 6:
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
			int timeHours = int.Parse(timeHoursTaskInputField.GetComponent<InputField> ().text);
			int timeSeconds = int.Parse(timeMinutesTaskInputField.GetComponent<InputField> ().text);	

			int timeconverted = convertPassedTimeToSeconds (timeHours, timeSeconds);		   
			
			task = Instantiate(task) as GameObject;

			task.GetComponent<Task> ()._name = name;
			task.GetComponent<Task> ()._timeInSeconds = timeconverted;
			task.GetComponent<Task> ()._id = UnityEngine.Random.Range (0, int.MaxValue);


			taskList.Add (task);

			//chamar metodo para povoar o panel de lista
			addTaskListPanel(task);
									
		}	   

		public int convertPassedTimeToSeconds(int hours,int minutes){			
			return minutes * 60 + hours *3600;
		}

		public void addTaskListPanel(GameObject task){

			Vector3 vector3;
			vector3.x = (float) 1.0000; 
			vector3.y = (float) 1.0000;
			vector3.z = 1;

			Vector2 vector2;
			vector2.x = (float) 412.8; 
			vector2.y = (float)95.644;


			Debug.Log (task.GetComponent<Task> ()._name);
			GameObject button = (GameObject) Instantiate (buttonPrefabs);
			button.GetComponentInChildren< RectTransform> ().localScale = vector3;
			button.GetComponentInChildren< RectTransform> ().sizeDelta = vector2;
		    button.GetComponentInChildren<Text>().text= task.GetComponent<Task> ()._name;
			button.transform.parent = gridElemets;


			//GameObject button = (GameObject) Instantiate (buttonPrefabs);
			//button.GetComponentInChildren< RectTransform> ().localScale = vector;
			//button.GetComponentInChildren<Text>().text= "Medicamento teste";


			//button.GetComponentInChildren< RectTransform> ().se.y = 1.0;
			//button.transform.parent = gridElemets;
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
=======
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
		public GameObject timeHoursTaskInputField;
		public GameObject timeMinutesTaskInputField;

		public GameObject listPanel;

		[SerializeField] Transform  gridElemets;
		[SerializeField]  GameObject buttonPrefabs;
		public GameObject robot;


		public GameObject task;
		List<GameObject> taskList;	     


		// Use this for initialization
		void Start () {
			taskList = new List<GameObject>();
			welcomeNotification ();
			Debug.Log ("felicidade do"+happinessText.GetComponent<Text> ().text );

			}
		
		// Update is called once per frame
		void Update () {
			happinessText.GetComponent<Text> ().text = "" + robot.GetComponent<Robot> ().happiness;	
			nameText.GetComponent<Text> ().text = robot.GetComponent<Robot> ().name;
		}

		public void buttonBehavior(int i){
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
			int timeHours = int.Parse(timeHoursTaskInputField.GetComponent<InputField> ().text);
			int timeSeconds = int.Parse(timeMinutesTaskInputField.GetComponent<InputField> ().text);	

			int timeconverted = convertPassedTimeToSeconds (timeHours, timeSeconds);		   
			
			task = Instantiate(task) as GameObject;

			task.GetComponent<Task> ()._name = name;
			task.GetComponent<Task> ()._timeInSeconds = timeconverted;
			task.GetComponent<Task> ()._id = UnityEngine.Random.Range (0, int.MaxValue);


			taskList.Add (task);

			//chamar metodo para povoar o panel de lista
			addTaskListPanel(task);
									
		}	   

		public int convertPassedTimeToSeconds(int hours,int minutes){			
			return minutes * 60 + hours *3600;
		}

		public void addTaskListPanel(GameObject task){

			Vector3 vector3;
			vector3.x = (float) 1.0000; 
			vector3.y = (float) 1.0000;
			vector3.z = 1;

			Vector2 vector2;
			vector2.x = (float) 412.8; 
			vector2.y = (float)95.644;


			Debug.Log (task.GetComponent<Task> ()._name);
			GameObject button = (GameObject) Instantiate (buttonPrefabs);
			button.GetComponentInChildren< RectTransform> ().localScale = vector3;
			button.GetComponentInChildren< RectTransform> ().sizeDelta = vector2;
		    button.GetComponentInChildren<Text>().text= task.GetComponent<Task> ()._name;
			button.transform.parent = gridElemets;


			//GameObject button = (GameObject) Instantiate (buttonPrefabs);
			//button.GetComponentInChildren< RectTransform> ().localScale = vector;
			//button.GetComponentInChildren<Text>().text= "Medicamento teste";


			//button.GetComponentInChildren< RectTransform> ().se.y = 1.0;
			//button.transform.parent = gridElemets;
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
>>>>>>> parent of 258fb2c... add some beautiful style in taskaPnel and listPanel
}