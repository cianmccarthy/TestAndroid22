using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleControlScript : MonoBehaviour, IInteractable
{


    bool is_selected = false;
    Renderer my_renderer;
    GameObject myCameraPlane;

    //Start is called before the first frame update
    void Start()
    {

        my_renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void select_toggle()
    {
        is_selected = !is_selected;

        if (is_selected)
        {
            my_renderer.material.color = Color.blue;
            gameObject.layer = 2;
        }

        else
        {
            my_renderer.material.color = Color.white;
            gameObject.layer = 0;
        }
    }

    public void dragStart()
    {

        myCameraPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        myCameraPlane.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
        myCameraPlane.transform.up = (Camera.main.transform.position - myCameraPlane.transform.position).normalized;
        myCameraPlane.GetComponent<Renderer>().enabled = false;
    }

    public void dragUpdate(Ray r)
    {
        RaycastHit info;

        if (Physics.Raycast(r, out info))
        {

            if (info.transform == myCameraPlane.transform)
            {
                Vector3 plane_hit = info.point;
                transform.position = plane_hit;
            }
        }
    }

    public void dragEnd()
    {
        Destroy(myCameraPlane);
    }

    public void dragActivated(Ray ray, float destination)
    {
       // throw new System.NotImplementedException();
    }
}
