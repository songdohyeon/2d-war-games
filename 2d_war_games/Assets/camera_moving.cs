using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class camera_moving : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float stopSpeed = 0.01f;

    private bool moveMouse;
    private Vector3 StartPosition;
    private Vector3 directionForce;
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        MoveCamera();
        StopCamera();
        UpdateCamera();
    }

    private void MoveCamera(){
        var m = _camera.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0)){
            CameraPositionStart(m);
        } else if(Input.GetMouseButton(0)){
            CameraPositionProgress(m);
        } else {
            CameraPositionEnd();
        }
    }
    private void StopCamera(){
        if(moveMouse){
            return ;
        }
        directionForce *= speed;
        if(directionForce.magnitude < stopSpeed){
            directionForce = Vector3.zero;
        }
    }
    private void UpdateCamera(){
        if(directionForce == Vector3.zero){
            return ;
        }

        var currenPosition = transform.position;
        var targetPosition = currenPosition + directionForce;
        transform.position = Vector3.Lerp(currenPosition, targetPosition, 0.5f);
    }

    private void CameraPositionStart(Vector3 sm){
        moveMouse = true;
        StartPosition = sm;
        directionForce = Vector2.zero;
    }
    private void CameraPositionProgress(Vector3 tm){
        if(!moveMouse){
            CameraPositionStart(tm);
        }
        directionForce = StartPosition - tm;
    }
    private void CameraPositionEnd(){
        moveMouse = false;
    }
}
