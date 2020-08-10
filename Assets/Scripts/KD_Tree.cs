using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KD_Tree : MonoBehaviour
{

    GameObject[] treeNodesArr;
    List<KD_Node> treeNodesList;
    public string tagName;
    private int totalNodeCount;
    // Start is called before the first frame update
    void Start()
    {
        SetTreeNodesArray();
        totalNodeCount = treeNodesArr.Length;
        treeNodesList = new List<KD_Node>();
    }

    private void SetTreeNodesArray(){
        treeNodesArr = GameObject.FindGameObjectsWithTag(tagName);
        Debug.Log(treeNodesArr[0].transform.position);
    }

    private void CreateKDTree(){
        if(treeNodesList.Count < 1){
            KD_Node root = new KD_Node(treeNodesArr[0], 0);
            root.SetIsRoot(true);
            treeNodesList.Add(root);
        } else {
            for (int i = 1; i < totalNodeCount; i++)
            {
                
            }
        }
    }

    private void InsertNode(GameObject _nodeObj){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
