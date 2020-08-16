using System;
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
        treeNodesList = new List<KD_Node>();
        nodeListDepth = 0;
        SetTreeNodesList();
    }

    private void SetTreeNodesList(){
        treeNodesArr = GameObject.FindGameObjectsWithTag(tagName);
        treeNodesList = new List<GameObject>(treeNodesArr);
        KDNodesList.Add(Insert(treeNodesList, 0));
        
    }

    /** BEGIN INSERT */
    private KD_Node Insert(List<GameObject> nodes, int _depth, KD_Node _parent = null){
        int currDim = _depth % dimensions;
        Debug.Log(currDim);
        KD_Node node;
        int median;
        /**
        * sort nodes[] using currDum and comparator (CmpX, CmpY, CmpZ)
        */
        if(_depth == 0) {
          nodes = CmpX(nodes);
        } else if(_depth % currDim == 2){
          nodes = CmpZ(nodes);
        } else if (_depth % currDim == 1){
          nodes = CmpY(nodes);
        } else {
          nodes = CmpX(nodes);
        }

        median = Mathf.FloorToInt(nodes.Count / 2);
        Debug.Log("median");
        Debug.Log(median);
        node = new KD_Node(nodes[median]);
        node.rightChild = Insert(nodes.GetRange(median + 1, nodes.Count), _depth + 1, node);
        node.leftChild = Insert(nodes.GetRange(0, median-1), _depth + 1, node);
        return node;
    }

    /** BEGIN COMPARE */
    private List<GameObject> CmpX(List<GameObject> _nodes) {
        return _nodes.Sort((a,b)=>{
          return a.gameObject.transform.position.x.CompareTo(b.gameObject.transform.position.x);
        });
    }

    private List<GameObject> CmpY(List<GameObject>  _nodes) {
        return _nodes.Sort((a,b)=>{
        return a.gameObject.transform.position.y.CompareTo(b.gameObject.transform.position.y);
        });
    }

    private List<GameObject> CmpZ(List<GameObject> _nodes) {
        return _nodes.Sort((a,b)=>{
        return a.gameObject.transform.position.z.CompareTo(b.gameObject.transform.position.z);
        });
    }
    /** END COMPARE */

    
    /** BEGIN SEARCH */
    // 1. Touch
    // 2. use touch position to identify object touched
    // 3. make object touched the ROOT
    // 4. use ROOT to search for child node objects
    // ---- right node: a. perform action, b. call SearchTree with right child as ROOT
    // ---- left node: a. perform action, b. call SearchTree with right child as ROOT

    
    // public KD_Node SearchTree(KD_Node _root, Vector3 _touchPos, int _depthLevel){
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
