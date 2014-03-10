using UnityEngine;
using System.Collections;

public class StarField : MonoBehaviour {

	private static StarField instance;
	public static StarField Instance
	{
		get
		{
			if (instance) instance = new StarField();
			return instance;
		}
	}

	public GameObject star;
	public GameObject starParent;

	private Camera cam;

	public int count = 0;
	public float minSize = 0.01f;
	public float maxSize = 0.1f;



	// Use this for initialization
	void Start () 
	{
		instance = this;

		cam = (Camera)GameObject.Find("Main Camera").GetComponent("Camera");

		GenerateStars();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void GenerateStars()
	{
		for (int i = 0; i <= count; i++)
		{
			float x = Random.Range(-100000, 100000);
			float y = Random.Range(-100000, 100000);

			float rotation = Random.Range(0, 360);

			float scale = Random.Range(minSize, maxSize);

			Vector3 pos = new Vector3(x, y, -1);



			GameObject inst = (GameObject)Instantiate(star, pos, Quaternion.Euler(new Vector3(0, 180, rotation)));
			inst.transform.localScale = new Vector3(scale, scale, scale);		
			inst.transform.parent = starParent.transform;
		}
	}
}
