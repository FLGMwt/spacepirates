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
	public List<MapObject> waypoints = new List<MapObject>();

	public bool isMapShowing;
	public int zoomStep;


	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		cam = GetComponent<Camera>();
		UpdateWaypoints();
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

		if (isMapShowing)
		{
			//manages camera zooms and clamps
			float s = (-zoomStep * camera.orthographicSize) * 0.03f;
			cam.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * s;
			if (camera.orthographicSize < 3f) {camera.orthographicSize = 3f;}
			if (camera.orthographicSize > 30) {camera.orthographicSize = 30;}
		}
	}

	public void UpdateWaypoints()
	{
		waypoints.Add(GameObject.Find("map_" + PlayerShip.Instance.target.name).GetComponent<MapObject>());
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
