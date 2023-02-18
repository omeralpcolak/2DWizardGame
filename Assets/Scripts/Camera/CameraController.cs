using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] Transform playerLocation;
    [SerializeField] float minY, maxY;
    [SerializeField] Transform background;
    Vector2 finalLocation;


    void Start()
    {
        finalLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        BackgroundMovement();
    }

    public void CameraMovement()
    {
        transform.position = new Vector3 (playerLocation.position.x,Mathf.Clamp(transform.position.y,minY,maxY),transform.position.z);
    }
    public void BackgroundMovement()
    {
        Vector2 transitionMovement = new Vector2 (transform.position.x-finalLocation.x,transform.position.y-finalLocation.y);
        background.position += new Vector3 (transitionMovement.x, transitionMovement.y,0f);
        finalLocation=transform.position;
    }
}
