using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidHandler : MonoBehaviour
{
    Touch touch;
    RaycastHit hit;
    private bool isRayCastHit = false;
    private string lastRayCastHit;

    void Start()
    {
        
    }

    private void HandleTouch(){
        touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if(touch.phase == TouchPhase.Began){
            if(isRayCastHit == false){
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

    private void SetLastHit(Collider col){
        if(lastRayCastHit == null || lastRayCastHit != col.name) {
            lastRayCastHit = col.name;
        } else {
            return;
        } 
    }

    private void ToggleTouchHitLimter(){
        isRayCastHit = (isRayCastHit == false) ? true : false;
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
