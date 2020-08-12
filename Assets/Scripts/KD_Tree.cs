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
            // compare z of root and tempNode
            // if (tempZ > rootZ): root.rightChild = tempNode
          } else if (arrIndex % 2 == 0) {
            // compare y
          } else {
            // compare x
          }
          currDepth += 1;
        }
        return root;
    }
  }


    // private void CmpX(root, temp){
      //    if(rootX < tempX): root.rightChild == temp;
      //    else: root.leftChild = temp
    // }
    
    // private void CmpY(root, temp){
      //    if(rootY < tempY): root.rightChild == temp;
      //    else: root.leftChild = temp
    // }

    // private void CmpZ(root, temp){
    //    if(rootZ < tempZ): root.rightChild == temp;
    //    else: root.leftChild = temp
    // }

        // while (nodeDepth < TreeDepth):
            // *** X ***
            // if ( node.x > tree[nodeDepth].x):
                // node = rightChild of tree[nodeDepth]
            // else:
                // node = leftChild of tree[nodeDepth]
            // nodeDepth += 1;
                // *** Y ***
                // if ( node.y > tree[nodeDepth].y):
                    // node = rightChild of tree[nodeDepth]
                // else:
                    // node = leftChild of tree[nodeDepth]
                // nodeDepth += 1;
                    // *** Z ***
                    // if(node.z > tree[nodeDepth].z)
                        // node = rightChild of tree[nodeDepth]
                    // else:
                        // node = leftChild of tree[nodeDepth]
