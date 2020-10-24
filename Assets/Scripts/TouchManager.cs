using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    
    Touch touch;
    RaycastHit hit;
    void Start()
    {
        Debug.Log("TOUCH CLASS");
    }

    private void HandleTouch(){
        touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if(touch.phase == TouchPhase.Began){
            HandleHit(ray);
        }
        if (touch.phase == TouchPhase.Moved) {
            HandleHit(ray);
        }
        if (touch.phase == TouchPhase.Ended) {
            // 
        }
    }

    private void HandleHit(Ray _ray){
        if(Physics.Raycast(_ray.origin, _ray.direction, out hit)){
            KD_Tree.SearchTree(hit.collider);
        }
    }

    public void OnCollisionEnter(Collision other) {
        foreach (ContactPoint contact in other.contacts)
        {
            // Debug.Log(contact);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            HandleTouch();
        }
    }
}
