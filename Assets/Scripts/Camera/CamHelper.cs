using UnityEngine;
using System.Collections;

/*-----
 * Manages zooming and possibly other camera features
 ------*/
public class CamHelper : MonoBehaviour
{
	public bool isMainCamera = true;
	
	public int zoomStep;
	
	// Use this for initialization
	void Start () 
	{
		Messenger.AddListener("ShowMap", SetInactive);
		Messenger.AddListener("HideMap", SetActive);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isMainCamera)
		{
			//manages camera zooms and clamps. 
			float s = (-zoomStep * camera.orthographicSize) * 0.03f;
			camera.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * s;
			if (camera.orthographicSize < 0.05f) {camera.orthographicSize = 0.05f;}
	 		if (camera.orthographicSize > 120000) {camera.orthographicSize = 120000;}
		}
	}

	void SetActive()
	{
		isMainCamera = true;
	}

	void SetInactive()
	{
		isMainCamera = false;
	}
}
