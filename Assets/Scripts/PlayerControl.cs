using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float normalSpeed;
    [SerializeField] private float sprintSpeed;
    private Vector3 move;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal") * Time.deltaTime * normalSpeed;
        move.z = Input.GetAxis("Vertical") * Time.deltaTime * normalSpeed;

        transform.Translate(move.x, 0, move.z, Space.World);
    }
}
