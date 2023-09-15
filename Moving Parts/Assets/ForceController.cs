using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ForceController : MonoBehaviour
{
    public Vector2 lastDirection;
    Rigidbody myRig;
    public float speed = 10.0f;
    public float maxSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        if (myRig == null)
            throw new System.Exception("Player controller needs rigidbody");
    }

    public void onMove(InputAction.CallbackContext ev)
    {
        if (ev.performed)
        {
            lastDirection = ev.ReadValue<Vector2>();
        }
        if (ev.canceled)
        {
            lastDirection = Vector2.zero;
        }
    }
    // Update is called once per frame
    void Update()
    {
        myRig.AddForce(transform.forward * speed * lastDirection.y, ForceMode.Acceleration);
        if (myRig.velocity.magnitude >= maxSpeed)
        {
            myRig.velocity = myRig.velocity.normalized * maxSpeed;
        }
        myRig.angularVelocity = new Vector3(0, lastDirection.x, 0) * maxSpeed;
    }
}