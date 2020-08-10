using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_Node : MonoBehaviour
{
    private int nodeId;
    private Vector3 nodePosition;
    private bool isRoot;

    public void SetNodeID(int _ID){
        this.nodeId = _ID;
    }

    public void SetNodePosition(Vector3 _nodePosition){
        this.nodePosition = _nodePosition;
    }

    public Vector3 GetNodePosition(){
        return this.nodePosition;
    }
}
