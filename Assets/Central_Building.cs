using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Central_Building : MonoBehaviour
{
	public int buildingHeight = 50;
	public float slidervalue = 1.0f;
	public float numberOfBuildings = 20.0f;
	public float buildingNumber = 20.0f;
	public float complexity = 10.0f;
	public Roads road;
	//private GameObject cluster = new GameObject();
	
	void  Start ()
	{
		
	}
	
	GameObject generateBuilding ()
	{
		GameObject cluster = new GameObject();
		GameObject cube = null;
		float buildComplexity = Mathf.RoundToInt(Random.Range(1.0f,2.0f));
		
		for (int i = 0; i < (buildComplexity*complexity) ; i++) {
			cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.localPosition = new Vector3 ((Random.Range (-1.5f, 1.5f)), Random.Range (0f, 1.0f),( Random.Range (-1.5f, 1.5f)));
			cube.transform.localScale = new Vector3 ((Random.Range (1f, 4.0f)), (Random.Range (1f, buildingHeight)), (Random.Range (1.0f, 4.0f)));
			cube.transform.parent = cluster.transform;
			cube.AddComponent<BoxCollider>().isTrigger = true;
			cube.AddComponent<Rigidbody>().isKinematic = false;
			cube.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			cube.rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			cube.tag = "CentralBuildings";
		}
		return cluster;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.transform.tag == "roadVertical") 
		{
			Debug.Log("collision test");
			//Destroy(GameObject.FindWithTag("CentralBuildings"));	
		}
	}

	void OnGUI()
	{
		buildingHeight = Mathf.RoundToInt( GUI.HorizontalSlider (new Rect (35, 15, 100, 30), buildingHeight, 1.0f, 50.0f));
		GUI.Box(new Rect(155, 15, 200, 30), "Building Height :" + buildingHeight*2 + "%");
		GUI.Label (new Rect (35, 25, 200, 30), "Building Height");
		
		buildingNumber = Mathf.RoundToInt(GUI.HorizontalSlider (new Rect (635, 15, 100, 30), buildingNumber, 1.0f, 20.0f));
		GUI.Box(new Rect(775, 15, 200, 30), "Number Of Buildings : " +  buildingNumber);
		GUI.Label (new Rect (635, 25, 200, 30), "Number Of Buildings");
		
		complexity = Mathf.RoundToInt(GUI.HorizontalSlider (new Rect (635, 55, 100, 30), complexity, 1.0f, 10.0f));
		GUI.Box(new Rect(775, 55, 200, 30), "Building Complexity : " +  complexity);
		GUI.Label (new Rect (635, 65, 200, 30), "Building Complexity");
		
		if (GUI.Button (new Rect (35, 55, 200, 30), "Build in sector 1")) 
		{
			for (int y = 0; y < buildingNumber; y++) {
				GameObject buildingCluster = generateBuilding();
				buildingCluster.transform.position = new Vector3 (Random.Range (-30.0f, 30.0f), 0, Random.Range (-30.0f, 30.0f));
				//buildingCluster.tag = "CentralBuildings";
			}
			
		}
		
		if (GUI.RepeatButton (new Rect (35, 95, 100, 30), "Clear")) {
			Application.LoadLevel (Application.loadedLevel);
		}
		
	}
}
