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
        Debug.Log(ray);
        if(touch.phase == TouchPhase.Began){
            // 
        }
        if (touch.phase == TouchPhase.Moved) {
            // 
        }
        if (touch.phase == TouchPhase.Ended) {
            // 
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
