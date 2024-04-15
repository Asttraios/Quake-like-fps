using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    [SerializeField] private float normalSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float mouseSensit;

    private Vector3 positionVector;
    private Vector3 rotationVector;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {
        positionVector.x = Input.GetAxis("Horizontal");
        positionVector.y = Input.GetAxis("UpDown");
        positionVector.z = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            positionVector = positionVector * maxSpeed;
        }

        positionVector = positionVector * normalSpeed;
        
        transform.Translate(positionVector.x, 0, positionVector.z, Space.Self);
        transform.Translate(0, positionVector.y, 0, Space.World);

        

        rotationVector = transform.rotation.eulerAngles;
        rotationVector.x -= Input.GetAxis("Mouse Y") * mouseSensit;
        rotationVector.y += Input.GetAxis("Mouse X") * mouseSensit;
       
        if(rotationVector.x > 180 && rotationVector.x < 360 )
        {
            rotationVector.x = Mathf.Clamp(rotationVector.x, 270, 360);
        }
        else if(rotationVector.x < 180 && rotationVector.x > 0)
        {
            rotationVector.x = Mathf.Clamp(rotationVector.x, 0, 90);
        }
   
        transform.rotation = Quaternion.Euler(rotationVector.x, rotationVector.y, 0);
        Debug.Log(rotationVector.x);
        //Debug.Log(rotationVector.y);
        
        

    }

    
}
