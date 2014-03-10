using UnityEngine;
using System.Collections;

public class DayCalendar : MonoBehaviour {

	private static DayCalendar instance;
	public static DayCalendar Instance
	{
		get
		{
			if (instance == null) instance = new DayCalendar();
			return instance;
		}
	}

	public int days = 1;
	public float speed; 

	public int displayMonth;
	public int displayYear; 
	public int displayDays; 

	private float tick = 0;

	void Awake () 
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		//1.01388 being 365/360 to normalize a year to a circle
		speed = GameManager.Instance.planetOrbitSpeedMultiplier * 1.01388f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		displayYear = days / 365;
		displayDays = days - (displayYear * 365);


	}

	void FixedUpdate()
	{


//		tick += speed + (Time.timeScale / 100);
		tick += speed;

		if (tick >= 1) 
		{
			days++;
//			tick = 0.0f;
			tick -= 1.0f;
		}

	}

	void LateUpdate()
	{

	}

	void OnGUI()
	{
		GUI.color = Color.white;
		GUI.Label(new Rect(5, 1, 100, 20), string.Format("{0}.{1}", displayDays, displayYear ));
	}
}
