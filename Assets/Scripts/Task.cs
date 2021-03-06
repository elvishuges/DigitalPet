﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.SimpleAndroidNotifications{
public class Task : MonoBehaviour {
	

	private int timeInSeconds;
	private string name;
	private int id;
    private bool alarmouENaoTomou = false;  

	// Use this for initialization
	void Start () {		
		Debug.Log ("na classe task");

			Debug.Log (_id);
			Debug.Log (_name);
			Debug.Log (_timeInSeconds);
			Debug.Log (_alarmouENaoTomou
			);
			Debug.Log (_alarmouENaoTomou
			);
			if(_timeInSeconds > 0  )
			  InvokeRepeating ("ScheduleCustom",_timeInSeconds,_timeInSeconds);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

		public void ScheduleCustom()
	{    
		_alarmouENaoTomou = true;

		var notificationParams = new NotificationParams
		{   

			Id = _id,
			Delay = TimeSpan.FromSeconds(0),
			Title = "Hora do Medicamento: " +_name,
			Message = "Cuide do seu Pet Digital",
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

	public string _name{
		get { return name;}
		set { name = value;}
	}

	public int  _timeInSeconds{
		get { return timeInSeconds;}
		set { timeInSeconds = value;}
    }

	public int  _id{
		get { return id;}
		set { id = value;}
	  }
	public bool  _alarmouENaoTomou{
			get { return alarmouENaoTomou;}
			set { alarmouENaoTomou = value;}
		}

	}
}
