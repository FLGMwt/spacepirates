using UnityEngine;
using System.Collections;

//-------------
// Displays a simple text based tag and dot on the screen
//-------------
public class ObjTag : MonoBehaviour {

	public Color textColor;
	bool display = true;
	public string text;
	public Camera cam;
	Vector3 loc;
	void Start()
	{
		if (cam == null)
		{
			cam = (Camera)GameObject.Find("Main Camera").GetComponent("Camera");
		}
	}

	void LateUpdate()
	{
		loc = cam.WorldToScreenPoint(transform.position);
	}
	// Use this for initialization
	void OnGUI()
	{
		
		
		if (display)
		{
			GUI.contentColor = textColor;

			
			GUI.Label(new Rect(loc.x + 2, Screen.height - loc.y + 2,100,30), text); 
			
//			GUI.Box(new Rect(loc.x-5, Screen.height - loc.y-5, 2,2), " ");
			GUI.Label(new Rect(loc.x, Screen.height - loc.y-10,100,100), ".");
						 
			
		}//display
		
	}//onGui
}
