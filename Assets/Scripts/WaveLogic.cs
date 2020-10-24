using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveLogic : MonoBehaviour
{
    // Start is called before the first frame update
    /**
    * - 1. Create list of children for each pyramid
    * - 2. Get entire list of all pyramids
    * - 3. IRT, upon touching pyramid, create tree:
    * -     a. touched pyr. is root,
    * -     b. parent = root / subsequent node (i.e., that has children)
    * -     c. create list of children of each node, excluding:
    * -         -- node's parent,
    * -         -- the children of node's siblings,
    * -     d... 
    * -         d.1. - if (all nodes have no children) : STOP
    * -         d.2. - if (some nodes still have children) : REPEAT 3.b - 3.d
    * - 4. 
    * - 5. 
    */
    private List<KD_Node> kdNodeList;
    void Start()
    {
        kdNodeList = new List<KD_Node>();
    }

    private void MakeWaves(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
