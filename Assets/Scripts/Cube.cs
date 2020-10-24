using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject pyramid;
    public Vector3 startPosition;
    public int dimensionCount;
    private float xAx, yAx, zAx;
    private Vector3 currPos;
    public float distanceMultiplier;
    public Quaternion pyramidRotation;
    private float startX, startY, startZ;
    private List<GameObject> pyramidList;
    

    void Start()
    {
        startX = startPosition.x;
        startY = startPosition.y;
        startZ = startPosition.z;
        pyramidList = new List<GameObject>();
        BuildCube();
    }



    private void BuildCube(){
       int name = 0;
        for (int x = 0; x < dimensionCount; x++){
            for (int y = 0; y < dimensionCount; y++){
                for (int z = 0; z < dimensionCount; z++){
                    xAx =  startX + x * distanceMultiplier;
                    yAx = startY + y * distanceMultiplier;
                    zAx = startZ + z * distanceMultiplier;
                    currPos = new Vector3(xAx, yAx, zAx);
                    GameObject clone = Instantiate(pyramid, currPos, pyramidRotation);
                    clone.transform.SetParent(transform);
                    name += 1;
                    clone.gameObject.name = "pyramid: " + name.ToString();
                    pyramidList.Add(clone);
                }
            }
        }
    }

    void Update()
    {
        
    }
}
