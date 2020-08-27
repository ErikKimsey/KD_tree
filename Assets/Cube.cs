using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject pyramid;
    public Vector3 startPosition;
    public int totalPyramids;
    

    void Start()
    {
        BuildCube();
    }

    private void BuildCube(){
        Vector3 currPos = startPosition;
        for (int i = 0; i < totalPyramids; i++)
        {
            // if(currPos == null){
                currPos = startPosition;
                GameObject clone = Instantiate(pyramid, currPos, Quaternion.identity);
            // } else {
                // Vector3 temp = DeterminePosition(i, );
            // }
        }
    }

    // private Vector3 DeterminePosition(int _index, Vector3 currPos){
        // Vector3 temp = n
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
