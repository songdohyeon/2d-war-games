using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class camera_moving : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move(){
        if(Input.GetMouseButton(0)){
            Vector3 m_pos = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0).normalized;
            Vector3 m_pos1 = m_pos * (speed * Time.deltaTime);
            if(m_pos1.magnitude > 1f){
                m_pos1 = m_pos1.normalized;
                Debug.Log(m_pos1);
            }
            this.transform.Translate(-m_pos1);
        }
    }
}
