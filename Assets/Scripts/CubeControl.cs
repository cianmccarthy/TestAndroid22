using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour, IInteractable
{

    bool selected = false;
    Renderer my_renderer;
    LayerMask mask;
    private float distance;
    private bool started;

    //for moving at a constant direction
    //float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

        my_renderer = GetComponent<Renderer>();
        mask = LayerMask.GetMask("Ground");
        // drag_position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void select_toggle()
    {
        selected = !selected;

        if (selected)
        {
            my_renderer.material.color = Color.red;
            gameObject.layer = 2;
        }

        else
        {
            my_renderer.material.color = Color.white;
            gameObject.layer = 0;
        }

    }

    public void dragEnd()
    {
    }


    public void dragStart()
    {

    }

    public void dragUpdate(Ray ray)
    {

        /*
        RaycastHit info;

        if (Physics.Raycast(ray, out info, 100.0f, plane))
        {

            if (info.transform && selected == true)
            {

                transform.position = info.point + info.normal * 0.5f;
            }
        }*/

        if (!started)
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            started = true;
        }

        transform.position = ray.GetPoint(distance);

    }

    public void dragActivated(Ray ray, float destination)
    {
        //throw new NotImplementedException();
    }
}