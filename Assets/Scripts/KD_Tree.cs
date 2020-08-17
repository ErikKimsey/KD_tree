﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KD_Tree : MonoBehaviour
{

    GameObject[] treeNodesArr;
    private static List<GameObject> treeNodesList;
    private static List<KD_Node> KDNodesList;
    public string tagName;
    public int dimensions = 3;
    private int totalNodeCount;
    private int nodeListDepth;
    private int globalDepth = 1;


    public float xAngle, yAngle, zAngle;
    void Start()
    {
        treeNodesList = new List<GameObject>();
        KDNodesList = new List<KD_Node>();
        nodeListDepth = 0;
        SetTreeNodesList();
    }

    private void SetTreeNodesList(){
        treeNodesArr = GameObject.FindGameObjectsWithTag(tagName);
        treeNodesList = new List<GameObject>(treeNodesArr);

        KDNodesList.Add(Insertion(treeNodesList, 0));
    }

    /** BEGIN INSERT */
    private KD_Node Insertion(List<GameObject> nodes, int _depth, KD_Node _parent = null){
        int currDim = _depth % dimensions;
        List<GameObject> orderedList = new List<GameObject>();
        KD_Node node;
        int median;

        if(nodes.Count == 1){
            node = new KD_Node(nodes[0]);
            return node;
        }

        if(nodes.Count <= 0){
            return null;
        }
        if(_depth == 0) {
          orderedList = CmpX(nodes);
        } else if(currDim == 2){
          orderedList = CmpZ(nodes);
        } else if (currDim == 1){
          orderedList = CmpY(nodes);
        } else {
          orderedList = CmpX(nodes);
        }

        median = Mathf.FloorToInt(orderedList.Count / 2);
        
        node = new KD_Node(orderedList[median]);
        
        int rightEnd = orderedList.Count - (median + 1);
        node.rightChild = Insertion(orderedList.GetRange(median+1, rightEnd), _depth + 1, node);
        node.leftChild = Insertion(orderedList.GetRange(0, median), _depth + 1, node);
        KDNodesList.Add(node);
        return node;
    }

    /** BEGIN COMPARE */
    private List<GameObject> CmpX(List<GameObject> _nodes) {
        _nodes.Sort((a,b)=> a.gameObject.transform.position.x.CompareTo(b.gameObject.transform.position.x));
        return _nodes;
    }

    private List<GameObject> CmpY(List<GameObject>  _nodes) {
        _nodes.Sort((a,b)=> a.gameObject.transform.position.y.CompareTo(b.gameObject.transform.position.y));
        return _nodes;
    }

    private List<GameObject> CmpZ(List<GameObject> _nodes) {
        _nodes.Sort((a,b)=> a.gameObject.transform.position.z.CompareTo(b.gameObject.transform.position.z));
        return _nodes;
    }
    /** END COMPARE */

    
    /** BEGIN SEARCH */
    public static void SearchTree(Collider _col){
        // perform action on Cube.142
        // KD_Node temp = treeNodesList.Find(x => x.nodeName == _col.name);
        // Debug.Log(temp.leftChild);
        // Debug.Log(temp.rightChild);
        
        // if(_root == null) return null;
        
        // int currAxis = 0;
        // while(currAxis < ){
        //     if(_touchPos.x < rootPos.x){

        //     }
        // }
    }
    /** END SEARCH */

    /** BEGIN ROTATION FUNC*/



    IEnumerator RotateNodes(){
        foreach (var item in treeNodesList){
            // item.RotateNode();
            yield return new WaitForSeconds(0.01f);
        }
    }
    /** END ROTATION FUNC*/

    /** BEGIN FIND TOUCHED */

    /** END FIND TOUCHED */
}
