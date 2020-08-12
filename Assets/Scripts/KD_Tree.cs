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
    }

    private void SetTreeNodesArray(){
        treeNodesArr = GameObject.FindGameObjectsWithTag(tagName);
        totalNodeCount = treeNodesArr.Length;
        // if(totalNodeCount > 0){
        //     for (int i = 0; i < totalNodeCount; i++)
        //     {
        //         treeNodesArr[i].transform.Rotate(xAngle, yAngle, zAngle, Space.World);
        //     }
        // }
        CreateKDTree();
    }

    private void CreateKDTree(){
          KD_Node root = null;
          // treeNodesList.Add(InsertNode(root, treeNodesArr[0], 0));
           for (int i = 0; i < treeNodesArr.Length; i++){
              root = InsertNode(root, treeNodesArr[i], i);
              treeNodesList.Add(root);
              Debug.Log(root.GetNodePosition());
           }
    }

    private KD_Node InsertNode(KD_Node root, GameObject newNode, int arrIndex){
        KD_Node tempNode = new KD_Node(newNode, arrIndex);
        if(root == null) return tempNode;
        int currDepth = 0;
        while(currDepth < treeNodesList.Count){
          if(currDepth % 3 == 0){
            // Debug.Log(root + "in z");
            CmpZ(root, tempNode);
            
          } else if (currDepth % 2 == 0) {
            // Debug.Log(root + "in y");
            CmpY(root, tempNode);
          } else {
            // Debug.Log(root + "in x");
            CmpX(root, tempNode);
          }
          currDepth += 1;
          Debug.Log(currDepth);

        }
        return root;
    }

    private void CmpX(KD_Node root, KD_Node temp){
         if(root.GetNodePosition().x < temp.GetNodePosition().x){
           root.rightChild = temp;
         } else {
          root.leftChild = temp;
        }
    }

    private void CmpY(KD_Node root, KD_Node temp){
      if(root.GetNodePosition().y < temp.GetNodePosition().y){
        root.rightChild = temp;
      } else {
        root.leftChild = temp;
      }
    }

    private void CmpZ(KD_Node root, KD_Node temp){
      if(root.GetNodePosition().z < temp.GetNodePosition().z){
        root.rightChild = temp;
      } else {
      root.leftChild = temp;
      }
    }
}
