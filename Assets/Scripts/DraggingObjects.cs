using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingObjects : MonoBehaviour
{

    [SerializeField]
    private Transform objectHolder;

    // The item we are currently holding
    private GameObject Item = null;

    private float throwForce;
    private float rayDist = 2.5f;
    
    private bool isThrowable;
    private bool isHolding;

    [SerializeField]
    private Camera playerCamera;

    private void Update()
    {

        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f);
        Ray ray = playerCamera.ViewportPointToRay(rayOrigin);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, rayDist))
            {
                Debug.DrawRay(transform.position, ray.direction, Color.red, rayDist);
                if(hit.collider.tag == "Grabbable")
                {
                    isHolding = true;
                    isThrowable = true;

                    if(isHolding == true)
                    {
                        Item = hit.collider.gameObject;
                            Item.transform.SetParent(objectHolder);
                                Item.gameObject.transform.position = objectHolder.transform.position;
                                Item.GetComponent<Rigidbody>().isKinematic = true;
                            Item.GetComponent<Rigidbody>().useGravity = false;
                        Item.GetComponent<BoxCollider>().enabled = false;
                    }

                }
            }

        }
        if (Input.GetMouseButton(1))
        {
            Item.GetComponent<Rigidbody>().isKinematic = false;
            Item.GetComponent<Rigidbody>().useGravity = true;
            Item.GetComponent<BoxCollider>().enabled = true;
            isHolding = false;
            isThrowable = false;
            objectHolder.DetachChildren();
        }   
    }
}
