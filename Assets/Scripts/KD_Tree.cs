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
            nodeListDepth += 1;
        } else {
            for (int i = 1; i < totalNodeCount; i++)
            {
                if(i % 3 == 0){

                } else if (i % 2 == 0){
                    
                } else {
                    // if (i-1 != root):
                        // if(arr[i] > arr[i-1]):
                            // arr[i] == arr[i-1].rightChild
                        // else:
                            // arr[i] == arr[i-1].leftChild
                }

            }
        }

        // if not root (dim 0):
        // -- if (dim % 3 == 0): compare Z
        //  -- if (dim % 2 == 0): compare Y
        //  -- else: compare X
    }

    private 



    private void InsertNode(GameObject _nodeObj){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
