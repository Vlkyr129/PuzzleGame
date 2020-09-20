using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class pickUpObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCamera;
    [SerializeField]
    float throwForce = 100;
    [SerializeField]
    float pickUpDistance = 3;
    float distanceToObject;
    bool isBeingCarried = false;
    bool collideWorld = false;
    float timePassed;
    Vector3 originalSize;

    private void Start()
    {
        originalSize = transform.localScale;
    }

    private void Update()
    {
        distanceToObject = Vector3.Distance(gameObject.transform.position, player.position);

        timePassed++;

        if (distanceToObject <= pickUpDistance && Input.GetMouseButtonDown(0) && isBeingCarried == false)
        {
            //Dotween Used!!!!
            transform.DOPunchScale(Vector3.one, 1);
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCamera;
            isBeingCarried = true;
            timePassed = 0;
            //Singleton
            Score.instance.AddScore();
        }
        if (isBeingCarried && timePassed >= 1)
        {
            
            //Allows player to throw carried item
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                
                GetComponent<Rigidbody>().AddForce(playerCamera.forward * throwForce);
                isBeingCarried = false;
            }
            //Allows player to simply drom item without any force
            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                isBeingCarried = false;
            }
            //Drops item if collides with worl objects
            if (collideWorld)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                isBeingCarried = false;
                collideWorld = false;
            }
        }

        //Reset gameObject
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(0, 10, 0);
            transform.localScale = originalSize;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBeingCarried && other.tag != "Ground")
        {
            collideWorld = true;
        }
    }
}
