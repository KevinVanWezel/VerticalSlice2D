﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_tracking : MonoBehaviour {

    public float maxStretch = 3f;
    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;

    private SpringJoint2D spring;
    private Transform catapult;
    private Rigidbody2D rigidbody;
    private Ray rayToMouse;
    private Ray LeftCatapultToProjectile;
    private float maxStretchsqr;
    private float circleradius;
    private bool clickedOn;
    private Vector2 prevVelocity;
    
     void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        catapult = spring.connectedBody.transform;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start () {
        LineRendererSetup();	
        rayToMouse = new Ray(catapult.position, Vector3.zero);
        LeftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
        maxStretchsqr = maxStretch * maxStretch;
        CircleCollider2D circle =  GetComponent<Collider2D>() as CircleCollider2D;
        circleradius = circle.radius;
    }

	void Update () {
        if (clickedOn)
            Dragging();
        
        if (spring != null)
        {
            if (!rigidbody.isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude)
            {
                Destroy(spring);
                rigidbody.velocity = prevVelocity;
            }
            if (!clickedOn)
<<<<<<< HEAD:vertical_slice2D/Assets/scripts/Player/projectile_tracking.cs
                prevVelocity = GetComponent<Rigidbody2D>().velocity;
            
=======
                prevVelocity = rigidbody.velocity;

>>>>>>> 6b581b958d307adf0df7b302585a462a8638a3cd:vertical_slice2D/Assets/scripts/projectile_tracking.cs
            LineRenererUpdate();
        }
        else
        {
            catapultLineFront.enabled = false;
            catapultLineBack.enabled = false;
        }
	}
    void LineRendererSetup()
    {
        catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
        catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

        catapultLineFront.sortingLayerName = "forground";
        catapultLineBack.sortingLayerName = "forground";

        catapultLineFront.sortingOrder = 3;
        catapultLineBack.sortingOrder = 1;
    }
    void OnMouseDown()
    {
        spring.enabled = false;
        clickedOn = true;
    }
     void OnMouseUp()
    {
        spring.enabled = true;
        rigidbody.isKinematic = false;
        clickedOn = false;
    }
    
    void Dragging ()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 catapultToMouse = mouseWorldPoint - catapult.position;

        if (catapultToMouse.sqrMagnitude > maxStretchsqr)
        {
            rayToMouse.direction = catapultToMouse;
            mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
        }

        mouseWorldPoint.z = 0f;
        transform.position = mouseWorldPoint;
    }
    void LineRenererUpdate()
    {
        Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
        LeftCatapultToProjectile.direction = catapultToProjectile;
        Vector3 holdPoint = LeftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleradius);
        catapultLineFront.SetPosition(1, holdPoint);
        catapultLineBack.SetPosition(1, holdPoint);


    }
}
 