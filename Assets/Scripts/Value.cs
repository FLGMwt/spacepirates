using UnityEngine;
using System.Collections;

public enum ValueType
{
	none,
	technology,
	asteroidData,
	rawMaterial,
	component
}



public class Value : MonoBehaviour 
{
	public int size;
	public Habitat origin;
	public Faction owner;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
