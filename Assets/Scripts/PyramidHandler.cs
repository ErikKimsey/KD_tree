using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidHandler : MonoBehaviour
{
    Touch touch;
    RaycastHit hit;
    private bool isRayCastHit = false;
    private string lastRayCastHit;
    private ContactPoint[] contactPoints;
    private List<Collider> collisions;

    void Start()
    {
        collisions = new List<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(" >>>>>>>>>>>>>> ");
        Debug.Log(lastRayCastHit);
        Debug.Log(other);
        Debug.Log(" <<<<<<<<<<<<<< ");
        if(other != null){
            collisions.Add(other);
        }
    }

    // private 

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision contacts: ");
        Debug.Log(other.contacts.Length);
    }

    private void HandleTouch(){
        touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if(touch.phase == TouchPhase.Began){
            if(this.isRayCastHit == false){
                HandleHit(ray);
                ToggleTouchHitLimter(); 
            } else {
                return;
            }
        }
        if (touch.phase == TouchPhase.Moved) {
            // HandleHit(ray);
        }
        if (touch.phase == TouchPhase.Ended) {
            ToggleTouchHitLimter();
        }
    }

    /**
    *** BEGIN :: HANDLE NEIGHBOR COLLISION 
    */

    private void RotateThisPyramid(Collider col){
        if(col.name == lastRayCastHit){
            col.transform.Rotate(45f, 45f, 45f, Space.Self);
        }
    }

    private void RotateNeighbors(Collider[] cols){
        foreach (var item in cols)
        {
            Debug.Log(item.name);
        }
    }



    IEnumerator HandleNeighborCollision(Collider col){

        yield return new WaitForSeconds(1.0f);
    }

    /**
    *** END :: HANDLE NEIGHBOR COLLISION 
    */

    private void SetLastHit(Collider col){
        if(this.lastRayCastHit == null || this.lastRayCastHit != col.name) {
            this.lastRayCastHit = col.name;
            RotateThisPyramid(col);
        } else {
            return;
        } 
    }

    private void ToggleTouchHitLimter(){
        this.isRayCastHit = (this.isRayCastHit == false) ? true : false;
    }

    private void HandleHit(Ray _ray){
        if(Physics.Raycast(_ray.origin, _ray.direction, out hit)){
            SetLastHit(hit.collider);
        }
    }

    void Update()
    {
        if(Input.touchCount > 0){
            HandleTouch();
        }
    }
}
