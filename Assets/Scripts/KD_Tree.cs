using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KD_Tree : MonoBehaviour
{

    GameObject[] treeNodesArr;
    List<KD_Node> treeNodesList;
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
    private KD_Node InsertNode(KD_Node root, GameObject newNode, int arrIndex){
        Debug.Log(arrIndex);
        KD_Node tempNode = new KD_Node(newNode, arrIndex);
        if(root == null) {
            return tempNode;
        }
        int currDepth = 1;
        while(currDepth < treeNodesList.Count){
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
    /** END SEARCH */

    /** BEGIN ROTATION FUNC*/



    IEnumerator RotateNodes(){
        foreach (var item in treeNodesList){
            item.RotateNode();
            yield return new WaitForSeconds(0.01f);
        }
    }
    /** END ROTATION FUNC*/
}
