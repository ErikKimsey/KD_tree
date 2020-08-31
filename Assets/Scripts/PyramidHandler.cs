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
    private float colliderRadius;
    private SphereCollider sphereCollider;
    private Collider[] neighbors;
    private SphereCollider parent;
    private bool hasRotated = false;    

    void Start()
    {
        collisions = new List<Collider>();
        sphereCollider = GetComponent<SphereCollider>();
        colliderRadius = sphereCollider.radius;
        GetNeighbors(colliderRadius);
    }
    
    private void GetNeighbors(float radius){
         neighbors = Physics.OverlapSphere(this.transform.position, radius);
        // Debug.Log(" >>>>>>>>>>>>>>>>>>");
        // Debug.Log(sphereCollider);
        //  foreach (var item in neighbors)
        //  {
        //     Debug.Log(item);
        //  }
        // Debug.Log(" <<<<<<<<<<<<<<<<<<");
    }

    public void SetParent(SphereCollider parent){
        this.parent = parent;
    }

    private void HandleTouch(){
        touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if(touch.phase == TouchPhase.Began){
            if(this.isRayCastHit == false){
                HandleHit(ray);
                // ToggleTouchHitLimter(); 
            } else {
                return;
            }
        }
        if (touch.phase == TouchPhase.Moved) {
            // HandleHit(ray);
        }
        if (touch.phase == TouchPhase.Ended) {
            // ToggleTouchHitLimter();
        }
    }

    /**
    *** BEGIN :: HANDLE NEIGHBOR COLLISION 
    */

    public void RotateThisPyramid(Collider col){
        if(col.name == lastRayCastHit){
            col.transform.Rotate(45f, 45f, 45f, Space.Self);
        }
        StartCoroutine(RotateNeighbors(neighbors));
        // StartCoroutine(RotateNeighbors(neighbors));
    }

    IEnumerator RotateNeighbors(Collider[] cols){
         Debug.Log(" >>>>>>>>>>>>>>>>>>");
        Debug.Log(sphereCollider.name);
        foreach (var item in cols)
        {
            Debug.Log(item);
        }
        Debug.Log(" <<<<<<<<<<<<<<<<<<");
        foreach (var item in cols){
            // if(item != sphereCollider){
                // Debug.Log(" >>>>>>>>>>>>>>>>>>");
                // Debug.Log("curr rotating");
                // Debug.Log(item.name);
                PerformRotation(item);
                // Debug.Log(" <<<<<<<<<<<<<<<<<<");
            // }
           yield return new WaitForSeconds(0.5f);
        }
    }

    private void PerformRotation(Collider col){
        col.transform.Rotate(45f, 45f, 45f);
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

    // private void ToggleTouchHitLimter(){
    //     this.isRayCastHit = (this.isRayCastHit == false) ? true : false;
    // }

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
