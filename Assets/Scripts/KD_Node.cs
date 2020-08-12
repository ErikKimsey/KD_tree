using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class KD_Node : MonoBehaviour
{
    private GameObject node;
    private int nodeId;
    private Transform nodeTransform;
    public KD_Node leftChild, rightChild;

    public KD_Node(GameObject _node, int _ID){
        this.node = _node;
        this.nodeId = _ID;  
        this.SetNodeTransform(this.node.transform);
    }

    public int GetNodeID(){
        return this.nodeId;
    }

    private void SetNodeTransform(Transform _transform){
        nodeTransform = _transform;
    }

    public Vector3 GetNodePosition(){
        return this.nodeTransform.position;
    }

    public void RotateNode(){
        // 
    }
}
