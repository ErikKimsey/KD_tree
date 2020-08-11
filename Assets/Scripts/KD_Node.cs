using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class KD_Node : MonoBehaviour
{
    private GameObject node;
    private int nodeId;
    private bool isRoot = false;
    private Transform nodeTransform;
    public KD_Node leftChild, rightChild;

    public KD_Node(GameObject _node, int _ID){
        this.node = _node;
        this.nodeId = _ID;  
    }

    public int GetNodeID(){
        return this.nodeId;
    }

    public void SetIsRoot(bool _isRoot){
        if(_isRoot) this.isRoot = true;
    }

    public bool GetIsRoot(){
        return this.isRoot;
    }

    public void SetNodeTransform(Transform _transform){
        nodeTransform = _transform;
    }

    public Vector3 GetNodePosition(){
        return this.nodeTransform.position;
    }

    public void RotateNode(){
        // 
    }
}
