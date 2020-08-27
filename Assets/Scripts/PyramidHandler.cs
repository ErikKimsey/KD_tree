using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
