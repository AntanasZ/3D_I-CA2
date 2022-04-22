using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    [SerializeField]
    private Transform pickupPosition;

    private Rigidbody pickupObject;
    private Ray ray;
    private bool isAttached;

    private void Start()
    {
        isAttached = false;
        pickupObject = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            switch(isAttached)
            {
                case false:
                    ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                    RaycastHit hitInfo;
                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        if (hitInfo.transform.tag.Equals("Lamp"))
                        {
                            AttachToPlayer();
                        }
                    }
                    break;
                case true:
                    DetachFromPlayer();
                    break;
            }
            
        }
    }

    private void AttachToPlayer()
    {
        isAttached = true;
        pickupObject.useGravity = false;
        gameObject.transform.position = pickupPosition.position;
        gameObject.transform.parent = GameObject.Find("Pickup Position").transform;
    }

    private void DetachFromPlayer()
    {
        isAttached = false;
        gameObject.transform.parent = null;
        pickupObject.useGravity = true;
    }
}
