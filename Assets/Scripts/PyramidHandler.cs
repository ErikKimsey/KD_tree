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
    private GameObject parent;

    void Start()
    {
        collisions = new List<Collider>();
        sphereCollider = GetComponent<SphereCollider>();
        colliderRadius = sphereCollider.radius;
        GetNeighbors(colliderRadius);
    }
    
    private void GetNeighbors(float radius){
         neighbors = Physics.OverlapSphere(this.transform.position, radius);
        Debug.Log(" >>>>>>>>>>>>>>>>>>");
         foreach (var item in neighbors)
         {
            Debug.Log(item);
         }
        Debug.Log(" <<<<<<<<<<<<<<<<<<");
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
        StartCoroutine(RotateNeighbors(neighbors));
    }

    IEnumerator RotateNeighbors(Collider[] cols){
        foreach (var item in cols){
           PerformRotation(item);
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
