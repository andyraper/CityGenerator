using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionDetection : MonoBehaviour
{
    public List<GameObject> roadsX = new List<GameObject>();
    public List<GameObject> roadsY = new List<GameObject>();
    public List<GameObject> buildingList = new List<GameObject>();
    public List<GameObject> buildingListOuter = new List<GameObject>();
    public List<GameObject> buildingListInner = new List<GameObject>();
    public List<GameObject> buildingListInner1 = new List<GameObject>();

    void Awake()
    {
        Globals.collisionDetection = this;
    }

    void CheckCollision()
    {

    }

    public void RoadCheck()
    {
        List<int> roadDeletedX = new List<int>();
        List<int> roadDeletedY = new List<int>();

        for (int i = 0; i < roadsX.Count; i++)
        {
            bool checkDestroy = true;
            for (int j = 0; j < roadsY.Count; j++)
            {
                if (roadsX[i].GetComponent<BoxCollider>().bounds.Intersects(roadsY[j].GetComponent<BoxCollider>().bounds))
                {
                    checkDestroy = false;
                    break;
                }
            }
            if (checkDestroy)
            {
                roadDeletedX.Add(i);
            }
        }

        for (int i = 0; i < roadsY.Count; i++)
        {
            bool checkDestroy = true;
            for (int j = 0; j < roadsX.Count; j++)
            {
                if (roadsY[i].GetComponent<BoxCollider>().bounds.Intersects(roadsX[j].GetComponent<BoxCollider>().bounds))
                {
                    checkDestroy = false;
                    break;
                }
            }
            if (checkDestroy)
            {
                roadDeletedY.Add(i);
            }
        }

        for (int i = 0; i < roadDeletedX.Count; i++)
        {
            Destroy(roadsX[roadDeletedX[i]]);
            roadsX.RemoveAt(roadDeletedX[i]);

            if (i >= roadDeletedX.Count)
            {
                break;
            }
        }

        for (int i = 0; i < roadDeletedY.Count; i++)
        {
            Destroy(roadsY[roadDeletedY[i]]);
            roadsY.RemoveAt(roadDeletedY[i]);

            if (i >= roadDeletedY.Count)
            {
                break;
            }
        }
    }

    public void BuildingCheck()
    {
        List<int> BuildingDelete = new List<int>();

        for (int i = 0; i < buildingList.Count; i++)
        {

            bool checkDestroy = true;

            for (int j = 0; j < roadsX.Count; j++)
            {

                if (buildingList[i].GetComponent<BoxCollider>().bounds.Intersects(roadsX[j].GetComponent<BoxCollider>().bounds))
                {
                    checkDestroy = false;

                    if (checkDestroy == false)
                    {
                        buildingList[i].SetActive(false);
                    }
                }

            }
        }

        for (int i = 0; i < buildingList.Count; i++)
        {
            bool checkDestroy = true;
            for (int j = 0; j < roadsY.Count; j++)
            {

                if (buildingList[i].GetComponent<BoxCollider>().bounds.Intersects(roadsY[j].GetComponent<BoxCollider>().bounds))
                {
                    checkDestroy = false;
                    if (checkDestroy == false)
                    {
                        Debug.Log("Destroy BUILDING");
                        buildingList[i].SetActive(false);
                    }
                }
            }

        }
    }

    public void BuildingCheckOuter()
    {
        List<int> BuildingDelete = new List<int>();

        for (int i = 0; i < buildingListOuter.Count; i++)
        {

            bool checkDestroy = true;

            for (int j = 0; j < roadsX.Count; j++)
            {

                if (buildingListOuter[i].GetComponent<BoxCollider>().bounds.Intersects(roadsX[j].GetComponent<BoxCollider>().bounds))
                {
                    checkDestroy = false;

                    if (checkDestroy == false)
                    {
                        buildingListOuter[i].SetActive(false);
                    }
                }

            }
        }

        for (int i = 0; i < buildingListOuter.Count; i++)
        {
            bool checkDestroy = true;
            for (int j = 0; j < roadsY.Count; j++)
            {

                if (buildingListOuter[i].GetComponent<BoxCollider>().bounds.Intersects(roadsY[j].GetComponent<BoxCollider>().bounds))
                {
                    checkDestroy = false;
                    if (checkDestroy == false)
                    {
                        Debug.Log("Destroy BUILDING");
                        buildingListOuter[i].SetActive(false);
                    }
                }
            }

        }
    }

    public void BuildingCheckInner1()
    {
        List<int> BuildingDelete = new List<int>();

        for (int i = 0; i < buildingListInner1.Count; i++)
        {

            bool checkDestroy = true;

            for (int j = 0; j < roadsX.Count; j++)
            {

                if (buildingListInner1[i].GetComponent<BoxCollider>().bounds.Intersects(roadsX[j].GetComponent<BoxCollider>().bounds))
                {
                    checkDestroy = false;

                    if (checkDestroy == false)
                    {
                        buildingListInner1[i].SetActive(false);
                    }
                }

            }
        }

        for (int i = 0; i < buildingListInner1.Count; i++)
        {
            bool checkDestroy = true;
            for (int j = 0; j < roadsY.Count; j++)
            {

                if (buildingListInner1[i].GetComponent<BoxCollider>().bounds.Intersects(roadsY[j].GetComponent<BoxCollider>().bounds))
                {
                    checkDestroy = false;
                    if (checkDestroy == false)
                    {
                        Debug.Log("Destroy BUILDING");
                        buildingListInner1[i].SetActive(false);
                    }
                }
            }

        }
    }

    public void BuildingCheckInner()
    {
        List<int> BuildingDelete = new List<int>();

        for (int i = 0; i < buildingListInner.Count; i++)
        {

            bool checkDestroy = true;

            for (int j = 0; j < roadsX.Count; j++)
            {

                if (buildingListInner[i].GetComponent<BoxCollider>().bounds.Intersects(roadsX[j].GetComponent<BoxCollider>().bounds))
                {
                    checkDestroy = false;

                    if (checkDestroy == false)
                    {
                        buildingListInner[i].SetActive(false);
                    }
                }

            }
        }

        for (int i = 0; i < buildingListInner.Count; i++)
        {
            bool checkDestroy = true;
            for (int j = 0; j < roadsY.Count; j++)
            {

                if (buildingListInner[i].GetComponent<BoxCollider>().bounds.Intersects(roadsY[j].GetComponent<BoxCollider>().bounds))
                {
                    checkDestroy = false;
                    if (checkDestroy == false)
                    {
                        Debug.Log("Destroy BUILDING");
                        buildingListInner[i].SetActive(false);
                    }
                }
            }

        }
    }

}
