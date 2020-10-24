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
    private List<GameObject> neighborsList;
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
        neighborsList = new List<GameObject>();
        GetNeighbors(colliderRadius);
    }
    
    private void GetNeighbors(float radius){
        neighbors = Physics.OverlapSphere(this.transform.position, radius);

        foreach (var item in neighbors)
            {
                Debug.Log("neighbors");
                Debug.Log(item);
            }

        SetNeighborsList();
    }

    private void SetNeighborsList(){
        foreach (var item in neighbors)
        {
            if(item.gameObject != this.gameObject){
                this.neighborsList.Add(item.gameObject);
            }
        }
    }

    public void SetParent(SphereCollider parent){
        this.parent = parent;
    }

    private void HandleTouch(){
        touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if(touch.phase == TouchPhase.Began){
            // if(this.isRayCastHit == false){
                HandleHit(ray);
                // ToggleTouchHitLimter(); 
            // } else {
            //     return;
            // }
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
        if(col.name == this.lastRayCastHit){
            col.transform.Rotate(45f, 45f, 45f, Space.Self);
        }
        StartCoroutine(RotateNeighbors(neighborsList));
        // StartCoroutine(RotateNeighbors(neighbors));
    }

    IEnumerator RotateNeighbors(List<GameObject> neighborsList){
        foreach (var item in neighborsList){
            PerformRotation(item);
           yield return new WaitForSeconds(0.5f);
        }
    }

    private void PerformRotation(GameObject col){
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
