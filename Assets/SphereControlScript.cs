using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControlScript : MonoBehaviour, IInteractable
{
    bool selected = false;
    Renderer my_renderer;
    Vector3 drag_position;
    float distance;
    GameObject camera_plane;

    GameObject IInteractable.gameObject => throw new System.NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {
        my_renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, drag_position, 0.5f);
    }

    public void dragStart()
    {
        camera_plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        camera_plane.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
        camera_plane.transform.up = (Camera.main.transform.position - camera_plane.transform.position).normalized;
        camera_plane.GetComponent<Renderer>().enabled = false;
    }

    public void dragEnd()
    {
        Destroy(camera_plane);
    }
    public void dragActivated(Ray our_ray, float destination)
    {
        Plane plane = new Plane(Vector3.up, Vector3.down);
        // print(Vector3.up);
        //   print(Vector3.down);

        if (plane.Raycast(our_ray, out destination))
        {

            Vector3 pointalongplane = our_ray.origin + (our_ray.direction * destination);
            pointalongplane.y = 0.1f;
            print(pointalongplane);
            drag_position = pointalongplane;
        }
    }

    public void dragUpdate(Ray ray)
    {
        //throw new System.NotImplementedException();
    }

    public void select_toggle()
    {
        selected = !selected;

        if (selected)
        {
            my_renderer.material.color = Color.yellow;

        }
        else
            my_renderer.material.color = Color.white;
    }

}