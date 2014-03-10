using UnityEngine;
using System.Collections;

public class CryoManager : MonoBehaviour {

	public Color textColor;
	public float timespeed = 1.0f;
	public bool isAsleep = false;

	public int dayToWakeUp;

	public int daysToSleep = 0;
//	string sDays = "";

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//controlling Time
		Time.timeScale = timespeed;
		if (timespeed > 100 ) timespeed = 100;
		if (timespeed < 1 ) timespeed = 1;

		if (isAsleep)
		{
			if (DayCalendar.Instance.days >= dayToWakeUp)
			{
				Wake();
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Sleep(365);

		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Wake();
				
		}

  	}

	public void Sleep(int days)
	{
		isAsleep = true;
		timespeed = 99f;
		dayToWakeUp = DayCalendar.Instance.days + days;

	}

	public void Wake()
	{
		isAsleep = false;
		timespeed = 1f;
	}

	void OnGUI()
	{
		GUI.color = textColor;

		if (isAsleep) 
		{
			GUI.Box(new Rect(-1, -1, Screen.width + 1, Screen.height + 1), "");
		}

//		sDays = GUI.TextField(new Rect(5, 25, 40, 20), sDays, 4);
//
//		if (GUI.Button(new Rect(45,  25, 20, 20), "S"))
//		{
//			if (int.TryParse(sDays, out daysToSleep))
//			{
//				Sleep(daysToSleep);
//			}
//
//			if (sDays == "") daysToSleep = 0;
//		}
	}
}
