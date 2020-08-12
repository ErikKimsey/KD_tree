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
        StartCoroutine(SetTreeNodesArray());
        treeNodesList = new List<KD_Node>();
        nodeListDepth = 0;
    }

    IEnumerator SetTreeNodesArray(){
        treeNodesArr = GameObject.FindGameObjectsWithTag(tagName);
        totalNodeCount = treeNodesArr.Length;
        if(totalNodeCount > 0){
            for (int i = 0; i < totalNodeCount; i++)
            {
                treeNodesArr[i].transform.Rotate(xAngle, yAngle, zAngle, Space.World);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    private void CreateKDTree(){
          InsertNode(null, treeNodesArr[0], 0);
           for (int i = 1; i < treeNodesArr.Length; i++){
              treeNodesList.Add(InsertNode(null, treeNodesArr[i],i));
           }
    }

    private KD_Node InsertNode(KD_Node root, GameObject newNode, int arrIndex){
        KD_Node tempNode = new KD_Node(newNode, arrIndex);
        if(root == null) return tempNode;
        int currDepth = 0;
        while(currDepth < treeNodesList.Count){
          if(arrIndex % 3 == 0){
            CmpZ(root, tempNode);
          } else if (arrIndex % 2 == 0) {
            CmpY(root, tempNode);
          } else {
            CmpX(root, tempNode);
          }
          currDepth += 1;
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
