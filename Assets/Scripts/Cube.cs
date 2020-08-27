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
    

    void Start()
    {
        startX = startPosition.x;
        Debug.Log(startX);
        startY = startPosition.y;
        Debug.Log(startY);
        startZ = startPosition.z;
        Debug.Log(startZ);
        BuildCube();
    }

    private void BuildCube(){
       
        for (int x = 0; x < dimensionCount; x++){
            for (int y = 0; y < dimensionCount; y++){
                for (int z = 0; z < dimensionCount; z++){
                    xAx =  startX + x * distanceMultiplier;
                    yAx = startY + y * distanceMultiplier;
                    zAx = startZ + z * distanceMultiplier;
                    currPos = new Vector3(xAx, yAx, zAx);
                    Debug.Log(currPos);
                    GameObject clone = Instantiate(pyramid, currPos, pyramidRotation);
                    clone.transform.SetParent(transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
