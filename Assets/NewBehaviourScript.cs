using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewBehaviourScript : MonoBehaviour
{
    public float buildingHeight = 100.0f;
    public float buildingNumber = 20.0f;
    public float complexity = 10.0f;
    public Roads road;

    private bool showGUI = false;

    void Start()
    {

    }

    GameObject generateBuilding()
    {
        int iComplexity = (int)complexity;
        GameObject cluster = new GameObject();
        GameObject cube = null;
        int buildComplexity = Random.Range(1, 2);

        for (int i = 0; i < (buildComplexity * iComplexity); i++)
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localPosition = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(0f, 1.0f), Random.Range(-1.5f, 1.5f));
            cube.transform.localScale = new Vector3(Random.Range(2.0f, 6.0f), Random.Range(0f, buildingHeight), Random.Range(2.0f, 6.0f));
            cube.transform.parent = cluster.transform;
            cube.AddComponent<BoxCollider>();
            Globals.collisionDetection.buildingList.Add(cube);
        }
        return cluster;
    }

    void OnGUI()
    {
        if (road.ShowGUIAfterRoads)
        {
            showGUI = GUI.Toggle(new Rect(35, 15, 200, 30), showGUI, "SECTOR ONE", "button");

            if (showGUI)
            {
                GUI.Box(new Rect(25, 5, 360, 230), "");

                buildingHeight = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(35, 115, 100, 30), buildingHeight, 1.0f, 50.0f));
                GUI.Box(new Rect(165, 115, 200, 30), "Building Height :" + buildingHeight * 2 + "%");
                GUI.Label(new Rect(35, 125, 200, 30), "Building Height");

                buildingNumber = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(35, 155, 100, 30), buildingNumber, 1.0f, 20.0f));
                GUI.Box(new Rect(165, 155, 200, 30), "Number Of Buildings : " + buildingNumber);
                GUI.Label(new Rect(35, 165, 200, 30), "Number Of Buildings");

                complexity = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(35, 195, 100, 30), complexity, 1.0f, 10.0f));
                GUI.Box(new Rect(165, 195, 200, 30), "Building Complexity : " + complexity);
                GUI.Label(new Rect(35, 205, 200, 30), "Building Complexity");

                if (GUI.Button(new Rect(35, 75, 200, 30), "Build"))
                {
                    for (int y = 0; y < buildingNumber; y++)
                    {
                        GameObject buildingCluster = generateBuilding();
                        buildingCluster.transform.position = new Vector3(Random.Range(-30.0f, 30.0f), 0, Random.Range(-30.0f, 30.0f));
                        buildingCluster.name = "Building";
                    }
                    Globals.collisionDetection.BuildingCheck();
                }
            }

            if (GUI.RepeatButton(new Rect(Screen.width - 200, Screen.height - 50, 100, 30), "Clear"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
