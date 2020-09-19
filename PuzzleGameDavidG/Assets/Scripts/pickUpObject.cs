using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class pickUpObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCamera;
    public float throwForce = 10;
    [SerializeField]
    float pickUpDistance = 3;
    float distanceToObject;
    bool hasPlayer;
    bool isBeingCarried = false;
    bool collideWorld = false;

    private void Update()
    {
        distanceToObject = Vector3.Distance(gameObject.transform.position, player.position);
        
        if (distanceToObject <= pickUpDistance && Input.GetButtonDown("E"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCamera;
            isBeingCarried = true;
        }
        if (isBeingCarried)
        {
            //Drops item if collides with worl objects
            if (collideWorld)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                isBeingCarried = false;
                collideWorld = false;
            }
            //Allows player to throw carried item
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                isBeingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCamera.forward * throwForce);
            }
            //Allows player to simply drom item without any force
            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                isBeingCarried = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBeingCarried)
        {
            collideWorld = true;
        }
    }
}
