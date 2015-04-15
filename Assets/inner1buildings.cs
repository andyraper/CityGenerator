using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inner1buildings : MonoBehaviour
{

    public float buildingHeight = 30.0f;
    public float buildingNumber = 200.0f;
    public float complexity = 3.0f;
    public Roads road;

    private bool showGUI = false;

    void Start()
    {

    }

    GameObject generateBuilding()
    {
        int iComplexity = (int)complexity;
        GameObject cluster = new GameObject();
        int buildComplexity = Random.Range(1, 2);

        for (int i = 0; i < (buildComplexity * iComplexity); i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localPosition = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0f, 1.0f), Random.Range(-0.5f, 0.5f));
            cube.transform.localScale = new Vector3(Random.Range(2.0f, 5.0f), Random.Range(0f, buildingHeight), Random.Range(2.0f, 5.0f));
            cube.AddComponent<BoxCollider>();
            cube.transform.parent = cluster.transform;
            Globals.collisionDetection.buildingListInner1.Add(cube);
        }
        return cluster;
    }

    void OnGUI()
    {

        if (road.ShowGUIAfterRoads)
        {
            showGUI = GUI.Toggle(new Rect(235, 15, 200, 30), showGUI, "SECTOR TWO", "button");

            if (showGUI)
            {
                GUI.Box(new Rect(225, 5, 360, 230), "");

                buildingHeight = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(235, 115, 100, 30), buildingHeight, 1.0f, 30.0f));
                GUI.Box(new Rect(365, 115, 200, 30), "Building Height :" + Mathf.RoundToInt((buildingHeight * 10) / 3) + "%");
                GUI.Label(new Rect(235, 125, 200, 30), "Building Height");

                buildingNumber = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(235, 155, 100, 30), buildingNumber, 1.0f, 200.0f));
                GUI.Box(new Rect(365, 155, 200, 30), "Number Of Buildings : " + buildingNumber);
                GUI.Label(new Rect(235, 165, 200, 30), "Number Of Buildings");

                complexity = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(235, 195, 100, 30), complexity, 1.0f, 3.0f));
                GUI.Box(new Rect(365, 195, 200, 30), "Building Complexity : " + complexity);
                GUI.Label(new Rect(235, 205, 200, 30), "Building Complexity");

                if (GUI.Button(new Rect(235, 75, 200, 30), "Build"))
                {
                    for (int x = 0; x < buildingNumber; x++)
                    {
                        GameObject buildingCluster_inner1 = generateBuilding();
                        buildingCluster_inner1.transform.position = new Vector3((Random.Range(-40.0f, 40.0f)), 0, (Random.Range(-40.0f, 40.0f)));
                        buildingCluster_inner1.name = "CheckDelete";
                    }
                    Globals.collisionDetection.BuildingCheckInner1();
                }
            }
        }
    }
}


