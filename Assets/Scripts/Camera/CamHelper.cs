using UnityEngine;
using System.Collections;

/*-----
 * Manages zooming and possibly other camera features
 ------*/
public class CamHelper : MonoBehaviour {
	
	#region Singleton Initation
//	private static CamHelper instance;
//	
//	public CamHelper()
//	{
//		if (instance != null)
//		{
//			Debug.LogError("Can't have two instances of CamHelper. Destroying..");
//			return;
//		}
//		
//		instance = this;
//	}
//	
//	public static CamHelper Instance
//	{
//		get
//		{
//			if (instance == null)
//			{
//				new CamHelper();	
//			}
//			return instance;
//		}
//	}
	#endregion
	
	public int zoomStep;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//manages camera zooms and clamps. 
		float s = (-zoomStep * camera.orthographicSize) * 0.03f;
		camera.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * s;
		if (camera.orthographicSize < 0.05f) {camera.orthographicSize = 0.05f;}
 		if (camera.orthographicSize > 120000) {camera.orthographicSize = 120000;}

	}
}
