using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Rigidbody myRig;
    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        if (myRig == null)
            throw new System.Exception("Player controller needs rigidbody");

        myRig.AddExplosionForce(10.0f, new Vector3(0, 0, 10.5f), 5.0f, 5.0f, ForceMode.Impulse);
        Collider[] hitColliders = Physics.OverlapSphere(new Vector3(0, 0, 10.5f), 5.0f);
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.gameObject.GetComponent<Rigidbody>().AddExplosionForce(10.0f, new Vector3(0, 0, 10.5f), 5.0f, 1.0f, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}