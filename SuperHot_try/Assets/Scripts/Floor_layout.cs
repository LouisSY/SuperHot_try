using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Floor_layout : MonoBehaviour
{

    public Vector3 count = Vector3.zero;
    public Vector3 floorSize = Vector3.zero;
    public List<Transform> cellInfo = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Create Ground")]
    private void CreateGround()
    {
        cellInfo.Clear();
        var childrenTransforms = this.GetComponentInChildren<Transform>();
        foreach (Transform t in childrenTransforms)
        {
            cellInfo.Add(t);
        }

        int target_cellNum = (int)(count.x * count.y * count.z);
        int origin_cellNum = cellInfo.Count;
        if(target_cellNum != origin_cellNum)
        {
            Debug.Log("The count of cells doesn't match");
        }

        // Calculate the position of each cell
        try
        {
            int index = 0;
            for(int x = 0; x < count.x; x++)
            {
                for(int z = 0; z < count.z; z++)
                {
                    Vector3 pos = new Vector3(x * floorSize.x, floorSize.y, z * floorSize.z);
                    cellInfo[index].localPosition = pos;
                    index++;
                }
            }
        } catch (ArgumentOutOfRangeException e) {
            Console.WriteLine("Catch ArgumentOutOfRangeException", e.Source);
        }

    }



}