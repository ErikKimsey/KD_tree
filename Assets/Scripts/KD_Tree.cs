using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KD_Tree : MonoBehaviour
{

    GameObject[] treeNodesArr;
    List<KD_Node> treeNodesList;
    public string tagName;
    // Start is called before the first frame update
    void Start()
    {
        SetTreeNodesArray();
        treeNodesList = new List<KD_Node>();
    }

    private void SetTreeNodesArray(){
        treeNodesArr = GameObject.FindGameObjectsWithTag(tagName);
        Debug.Log(treeNodesArr[0].transform.position);
    }

    private void CreateKDTree(){
        foreach (var item in treeNodesArr)
        {
            
        }
    }

    private void InsertNode(GameObject ){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
