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

    public float xAngle, yAngle, zAngle;
    void Start()
    {
        treeNodesList = new List<KD_Node>();
        nodeListDepth = 0;
        SetTreeNodesArray();
        CreateKDTree();
    }

    private void SetTreeNodesArray(){
        treeNodesArr = GameObject.FindGameObjectsWithTag(tagName);
    }

    private void CreateKDTree(){
          KD_Node root = null;
           for (int i = 0; i < treeNodesArr.Length; i++){
              root = InsertNode(root, treeNodesArr[i], i);
              treeNodesList.Add(root);
           }
           StartCoroutine(RotateNodes());
    }

    /** BEGIN INSERT */
    private KD_Node InsertNode(KD_Node root, GameObject newNode, int _depth){
        KD_Node tempNode = new KD_Node(newNode, _depth);
        if(root == null) {
            return tempNode;
        }
        int currDepth = 0;
        while(currDepth < _depth){
          if(currDepth % 3 == 0){
            CmpZ(root, tempNode);
          } else if (currDepth % 2 == 0) {
            CmpY(root, tempNode);
          } else {
            CmpX(root, tempNode);
          }
          currDepth = currDepth + 1;
        }
        return tempNode;
    }

    private void CmpX(KD_Node root, KD_Node temp){
         if(root.GetNodePosition().x <= temp.GetNodePosition().x){
           root.rightChild = temp;
         } else {
          root.leftChild = temp;
        }
    }

    private void CmpY(KD_Node root, KD_Node temp){
      if(root.GetNodePosition().y <= temp.GetNodePosition().y){
        root.rightChild = temp;
      } else {
        root.leftChild = temp;
      }
    }

    private void CmpZ(KD_Node root, KD_Node temp){
      if(root.GetNodePosition().z <= temp.GetNodePosition().z){
        root.rightChild = temp;
      } else {
        root.leftChild = temp;
      }
    }

    /** END INSERT */
    
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
        Debug.Log(temp.GetNodePosition());
        
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
