using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform cameraTarget;
    public float cameraSpeed; // camera's speed moving towards target
    public Vector2 cameraMax;
    public Vector2 cameraMin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Update every frame, LateUpdate last
    void LateUpdate()  
    {
        if(transform.position != cameraTarget.position) 
        {
            Vector3 targetPosition = new Vector3(cameraTarget.position.x, cameraTarget.position.y, transform.position.z);
            
            // Setting camera boundaries
            targetPosition.x = Mathf.Clamp(targetPosition.x, cameraMin.x, cameraMax.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, cameraMin.y, cameraMax.y);

            // linear interpolation- find distance between it and target, move % of that distance e/frame
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed);
     

        }
    }
}
