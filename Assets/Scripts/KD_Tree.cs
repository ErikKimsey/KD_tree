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
    public float xAngle, yAngle, zAngle;
    void Start()
    {
        StartCoroutine(SetTreeNodesArray());
        treeNodesList = new List<KD_Node>();
    }

    IEnumerator SetTreeNodesArray(){
        treeNodesArr = GameObject.FindGameObjectsWithTag(tagName);
        totalNodeCount = treeNodesArr.Length;
        // Debug.Log(totalNodeCount);
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
