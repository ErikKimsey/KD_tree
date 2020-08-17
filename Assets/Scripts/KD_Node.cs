using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class KD_Node 
{
    private GameObject node;
    private int nodeDepth;
    private Transform nodeTransform;
    public string nodeName;
    public KD_Node leftChild, rightChild;   

    public KD_Node(GameObject _node){
        this.node = _node;
        this.nodeName = this.node.name;
        this.SetNodeTransform(this.node.transform);
    }

    public int GetNodeID(){
        return this.nodeDepth;
    }

    private void SetNodeTransform(Transform _transform){
        nodeTransform = _transform;
    }

    public Vector3 GetNodePosition(){
        return this.nodeTransform.position;
    }

    public void RotateNode(){
        Vector3 upScale = new Vector3(1f,1f,1f);
        this.nodeTransform.Rotate(45f, 90f, 0f, Space.World);
        this.nodeTransform.localScale += upScale;
    }
}
