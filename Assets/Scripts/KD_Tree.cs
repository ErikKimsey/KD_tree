using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KD_Tree : MonoBehaviour
{

    GameObject[] treeNodesArr;
    private static List<KD_Node> treeNodesList;
    public string tagName;
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
        for(int i= 0; i <treeNodesArr.Length; i++)
        {
            KD_Node node = new KD_Node(treeNodesArr[i]);
            treeNodesList.Add(node);
        }
        StartCoroutine(RotateNodes());
    }
    
    /** BEGIN ASSIGN CHILDREN */
    private void AssignChildren(){
        for (int i = 0; i < treeNodesList.Count; i++){
            Insert(treeNodesList[i], treeNodesList[i+1]);
        }
        foreach (var item in treeNodesList){
            Debug.Log(item.leftChild);
            Debug.Log(item.rightChild);
        }
    }
    /** END ASSIGN CHILDREN */


    /** BEGIN INSERT */
    private void Insert(KD_Node _root, KD_Node _child){
        Insertion(_root, _child, globalDepth);
    }
  
    private void Insertion(KD_Node _root, KD_Node _child, int _depth){
        if(_depth % 3 == 0) {
            CmpZ(_root, _child, _depth);
        } else if (_depth % 2 == 0) {
            CmpY(_root, _child, _depth);
        } else {
            CmpX(_root, _child, _depth);
        }
    }
    /** END INSERT */

    private int IncrDepth(int _depth) {
        return _depth + 1;
    }

    /** BEGIN COMPARE */
    private void CmpX(KD_Node _root, KD_Node _child, int _depth) {
         if(_root.GetNodePosition().x <= _child.GetNodePosition().x){
           _root.rightChild = _child;
         } else {
          _root.leftChild = _child;
        }
        _depth = IncrDepth(_depth);
        Insertion(_root, _child, _depth);
    }

    private void CmpY(KD_Node _root, KD_Node _child, int _depth) {
      if(_root.GetNodePosition().y <= _child.GetNodePosition().y){
        _root.rightChild = _child;
      } else {
        _root.leftChild = _child;
      }
      _depth = IncrDepth(_depth);
      Insertion(_root, _child, _depth);
    }

    private void CmpZ(KD_Node _root, KD_Node _child, int _depth) {
      if(_root.GetNodePosition().z <= _child.GetNodePosition().z){
        _root.rightChild = _child;
      } else {
        _root.leftChild = _child;
      }
      _depth = IncrDepth(_depth);
      Insertion(_root, _child, _depth);
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
