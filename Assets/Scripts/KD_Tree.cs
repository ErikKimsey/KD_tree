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
        if(treeNodesList.Count < 1){
            KD_Node root = new KD_Node(treeNodesArr[0], 0);
            root.SetIsRoot(true);
            treeNodesList.Add(root);
        } else {
           for (int i = 1; i < treeNodesArr.Length; i++){
               CompareBuildTree(treeNodesArr[i], i);
           }
        }
    }

    private void CompareBuildTree(GameObject newNode, int arrIndex){
        KD_Node tempNode = new KD_Node(newNode, arrIndex);
        int nodeDepth = 1;
        while (nodeDepth < treeNodesList.Count)
        {
            if(nodeDepth % 3 == 0){
                CmpZ(tempNode, nodeDepth, arrIndex);
            } else if (nodeDepth % 2 == 0){
                CmpY(tempNode, nodeDepth, arrIndex);
            } else {
                CmpX(tempNode, nodeDepth, arrIndex);
            }
            nodeDepth += 1;
        }
        treeNodesList.Add(tempNode);
    }

    private void CmpX(KD_Node _tempNode, int _nodeDepth, int _arrIndex){
        
    }
    
    private void CmpY(KD_Node _tempNode, int _nodeDepth, int _arrIndex){}

    private void CmpZ(KD_Node _tempNode, int _nodeDepth, int _arrIndex){}

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


    }



    private void InsertNode(GameObject _nodeObj){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
