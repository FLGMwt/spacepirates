using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public class MapCamera : MonoBehaviour 
{
	private static MapCamera instance;
	public static MapCamera Instance
	{
		get
		{
			if (instance == null) instance = new MapCamera();
			return instance;
		}
	}


	public Camera cam;
	public List<MapObject> mapWaypoints = new List<MapObject>();

	public bool isMapShowing;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			if (!isMapShowing) ShowMap();
			else
			{
				HideMap();
			}
		}
	}

	public void ShowMap()
	{
		isMapShowing = true;
		cam.depth = 1;
		Messenger.Broadcast("ShowMap");
	}

	public void HideMap()
	{
		isMapShowing = false;
		cam.depth = -2;
		Messenger.Broadcast("HideMap");
	}
}
