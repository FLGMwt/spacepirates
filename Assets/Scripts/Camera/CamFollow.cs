using UnityEngine;
using System.Collections;

/// <summary>
/// Should really just be follow, has this object follow another transform at a certain lerp
/// </summary>
public class CamFollow : MonoBehaviour 
{
	
	public Transform target;
	public float smooth;
	
	Vector3 temp;

	public bool snap;
	// Use this for initialization
	void Start () 
	{
		temp = new Vector3(0,0,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
	{


	}
	
	void LateUpdate () 
	{
		Follow();
	}
	
	void FixedUpdate()
	{

	}

	void Follow()
	{
		if (!snap)
		{
			temp.x = Vector3.Lerp(transform.position, target.position, smooth).x;
			temp.y = Vector3.Lerp(transform.position, target.position, smooth).y;
			
		}
		
		else
		{
			temp.x = target.position.x;
			temp.y = target.position.y;
		}
		
		transform.position = temp;
	}
}
