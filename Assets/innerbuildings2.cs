using UnityEngine;
using System.Collections;

public class innerbuildings2 : MonoBehaviour
{

    public float buildingHeight = 15.0f;
    public float buildingNumber = 500.0f;
    public float complexity = 3.0f;
    public Roads road;

    private bool showGUI = false;

    void Start()
    {

    }

    void OnGUI()
    {

        if (road.ShowGUIAfterRoads)
        {
            showGUI = GUI.Toggle(new Rect(435, 15, 200, 30), showGUI, "SECTOR THREE", "button");

            if (showGUI)
            {
                GUI.Box(new Rect(425, 5, 360, 230), "");

                buildingHeight = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(435, 115, 100, 30), buildingHeight, 1.0f, 15.0f));
                GUI.Box(new Rect(565, 115, 200, 30), "Building Height :" + Mathf.RoundToInt((buildingHeight)) + "%");
                GUI.Label(new Rect(435, 125, 200, 30), "Building Height");

                buildingNumber = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(435, 155, 100, 30), buildingNumber, 1.0f, 500.0f));
                GUI.Box(new Rect(565, 155, 200, 30), "Number Of Buildings : " + buildingNumber);
                GUI.Label(new Rect(435, 165, 200, 30), "Number Of Buildings");

                complexity = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(435, 195, 100, 30), complexity, 1.0f, 3.0f));
                GUI.Box(new Rect(565, 195, 200, 30), "Building Complexity : " + complexity);
                GUI.Label(new Rect(435, 205, 200, 30), "Building Complexity");

                if (GUI.Button(new Rect(435, 75, 200, 30), "Build in sector 3"))
                {
                    for (int x = 0; x < buildingNumber; x++)
                    {

                        GameObject buildingCluster_inner1 = generateBuilding();
                        buildingCluster_inner1.transform.position = new Vector3(Random.Range(-100.0f, 100.0f), 0, Random.Range(-100.0f, 100.0f));
                        buildingCluster_inner1.name = "buildingCluster_inner2";
                    }
                    Globals.collisionDetection.BuildingCheckInner();
                }
            }
        }
    }

    GameObject generateBuilding()
    {
        GameObject cluster = new GameObject();

        for (int i = 0; i < 3; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localPosition = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0f, 1.0f), Random.Range(-0.5f, 0.5f));
            cube.transform.localScale = new Vector3(Random.Range(2.0f, 3.0f), Random.Range(0f, 20.0f), Random.Range(2.0f, 3.0f));
            cube.AddComponent<BoxCollider>();
            cube.transform.parent = cluster.transform;
            Globals.collisionDetection.buildingListInner.Add(cube);
        }
        return cluster;
    }
}
