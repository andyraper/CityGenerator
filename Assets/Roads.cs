using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Roads : MonoBehaviour
{
    private int numberofPoints = 200;
    public bool ShowGUIAfterRoads = false;
    private bool clicked = false;

    void Start()
    {

    }

    void OnGUI()
    {
        if (!clicked)
        {
            if (GUI.Button(new Rect(35, 555, 200, 30), "Build Roads"))
            {
                MovePointInX();
                MovePointInY();
                Globals.collisionDetection.RoadCheck();
                ShowGUIAfterRoads = true;
                clicked = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Move roads Horizontally 
    void MovePointInX()
    {
        for (int i = 0; i < numberofPoints; i++)
        {
            GameObject go = createPointInX();
            go.transform.position += new Vector3(0, 0, ((((float)(Random.Range(-20, 20)) * 10.0f))));
            Globals.collisionDetection.roadsX.Add(go);
            go.transform.name += Globals.collisionDetection.roadsX.Count;
        }
    }

    //create roads horizontally 
    GameObject createPointInX()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.localScale = new Vector3((float)(Random.Range(3, 10) * 10.0f), 0.15f, 2.0f);
        go.transform.position = new Vector3((float)(Random.Range(-15, 15) * 10.0f), 0.0f, 0.0f);
        go.GetComponent<Renderer>().material.color = Color.black;
        go.GetComponent<BoxCollider>().size = new Vector3(go.GetComponent<BoxCollider>().size.x, 200.0f, go.GetComponent<BoxCollider>().size.z);
        go.name = "roadHorizontal";
        return go;
    }

    //move roads vertically 
    void MovePointInY()
    {
        for (int i = 0; i < numberofPoints; i++)
        {
            GameObject go = createPointInY();
            go.name = "roadVertical";
            go.transform.position += new Vector3(0, 0, ((float)Random.Range(-20, 20) * 10.0f));
            Globals.collisionDetection.roadsY.Add(go);
        }
    }

    //create roads vertically
    GameObject createPointInY()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.localScale = new Vector3(2.0f, 0.15f, ((float)Random.Range(3, 10) * 10.0f));
        go.transform.position = new Vector3(((float)Random.Range(-15, 15) * 10.0f), 0.0f, 0.0f);
        go.GetComponent<Renderer>().material.color = Color.black;
        go.GetComponent<BoxCollider>().size = new Vector3(go.GetComponent<BoxCollider>().size.x, 200.0f, go.GetComponent<BoxCollider>().size.z);
        return go;
    }
}
