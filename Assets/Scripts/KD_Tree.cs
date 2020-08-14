using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KD_Tree : MonoBehaviour
{

    GameObject[] treeNodesArr;
    private static List<KD_Node> treeNodesList;
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
        treeNodesList.Add(Insert(treeNodesArr, 0));
        
    }

    /** BEGIN INSERT */
    private KD_Node Insert(GameObject[] nodes, int _depth, KD_Node _parent = null){
        int currDim = _depth % dimensions;
        KD_Node node;
        int median;
        /**
        * sort nodes[] using currDum and comparator (CmpX, CmpY, CmpZ)
        */
        median = Mathf.FloorToInt(nodes.Length / 2);
        node = new KD_Node(nodes[median]);
        node.rightChild = Insert(SplitRight(nodes, median), _depth + 1, node);
        node.leftChild = Insert(SplitRight(nodes, median), _depth + 1, node);
        return node;
    }

    private GameObject[] SplitRight(GameObject[] nodes, int median){
        GameObject[] right = new GameObject[]{};
        for (int i = 0; i < median; i++){
            right[i] = nodes[i];
        }
        return right;
    }
    
    private GameObject[] SplitLeft(GameObject[] nodes, int median){
        GameObject[] left = new GameObject[]{};
        for (int i = median; i < nodes.Length; i++){
            left[i] = nodes[i];
        }
        return left;
    }
    /** END INSERT */

    private int IncrDepth(int _depth) {
        globalDepth += 1;
        return globalDepth;
    }

    /** BEGIN COMPARE */
    private void CmpX(KD_Node _root, KD_Node _child, int _depth) {
         if(_root.GetNodePosition().x <= _child.GetNodePosition().x){
           _root.rightChild = _child;
         } else {
          _root.leftChild = _child;
        }
    }

    private void CmpY(KD_Node _root, KD_Node _child, int _depth) {
      if(_root.GetNodePosition().y <= _child.GetNodePosition().y){
        _root.rightChild = _child;
      } else {
        _root.leftChild = _child;
      }
    }

    private void CmpZ(KD_Node _root, KD_Node _child, int _depth) {
      if(_root.GetNodePosition().z <= _child.GetNodePosition().z){
        _root.rightChild = _child;
      } else {
        _root.leftChild = _child;
      }
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
        KD_Node temp = treeNodesList.Find(x => x.nodeName == _col.name);
        Debug.Log(temp.leftChild);
        Debug.Log(temp.rightChild);
        
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
            item.RotateNode();
            yield return new WaitForSeconds(0.01f);
        }
    }
    /** END ROTATION FUNC*/

    /** BEGIN FIND TOUCHED */

    /** END FIND TOUCHED */
}
