using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KD_Tree : MonoBehaviour
{

    private GameObject[] treeNodesArr;
    private static List<GameObject> treeNodesList;
    private static List<KD_Node> KDNodesList;

    public string tagName;
    public int dimensions = 3;

    void Start()
    {
        treeNodesList = new List<GameObject>();
        KDNodesList = new List<KD_Node>();
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
       KD_Node target = null;
       target = KDNodesList.Find(x => x.nodeName == _col.name);
       if(target == null) return;
       RotateNodes(target);

    }

    private void MakeWave(KD_Node _currNode){
        // 1. define radius
        // 2. get objects in radius
        // 3. set list of object who've performed action
        // 4. if object not in (^) list: perform action on objects in radius
        // 5. recursively: Steps 2 - 4
    }
    /** END SEARCH */

    /** BEGIN ROTATION FUNC*/
    private static void RotateNodes(KD_Node _target){
         
        _target.RotateNode();

        if(_target.leftChild != null && _target.rightChild != null) {
            RotateNodes(_target.leftChild);
            RotateNodes(_target.rightChild);
        } 

        if(_target.rightChild != null && _target.leftChild == null) {
            RotateNodes(_target.rightChild);
        }

        if(_target.rightChild == null && _target.leftChild != null) {
            RotateNodes(_target.leftChild);
        }
    }
    /** END ROTATION FUNC*/

    /** BEGIN FIND TOUCHED */

    /** END FIND TOUCHED */
}
