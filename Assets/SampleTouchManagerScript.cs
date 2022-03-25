using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTouchManagerScript : MonoBehaviour, ITouchController
{


    IInteractable selected_object;
    Quaternion startOrientation;
    Vector3 scale;
    Quaternion cameraStarting;

    bool twoFinDrag = false;
    bool dragStart = false;
    private bool pinchStart;

    bool rotate_started = false;
    private float starting_distance_to_selected_object;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void drag(Vector2 current_position)
    {

        Ray ourRay = Camera.main.ScreenPointToRay(current_position);

        Debug.DrawRay(ourRay.origin, 30 * ourRay.direction);


        if (selected_object != null)
        {
            ourRay = Camera.main.ScreenPointToRay(current_position);
            selected_object.dragActivated(ourRay, starting_distance_to_selected_object);

            if (!dragStart)
            {
                selected_object.dragStart();
                dragStart = true;
            }

            selected_object.dragUpdate(ourRay);

        }



    }

    public void dragEnd()
    {
        dragStart = false;
        if (selected_object != null)
        {
            selected_object.dragEnd();
        }
    }

    public void pinch(float startDist, float endDist, float relDistance)
    {

        if (!pinchStart)
        {
            if (selected_object != null)
            {
                startOrientation = selected_object.gameObject.transform.rotation;
                scale = selected_object.gameObject.transform.localScale;
            }
            else
            {
                startOrientation = Camera.main.transform.rotation;
            }
            pinchStart = true;
        }
        else
        {
            if (selected_object != null)
            {
                selected_object.gameObject.transform.localScale = scale * relDistance;
            }
            else
                Camera.main.transform.position += ((endDist - startDist) / 1000) * transform.forward;
        }


    }

    public void pinchEnd()
    {
        pinchStart = false;
    }

    public void rotate(float angle)
    {
        if (selected_object != null)
        {
            if (!rotate_started)
            {
                //selected_object.rotate_start();
                rotate_started = true;
            }
            selected_object.gameObject.transform.rotation = startOrientation * Quaternion.AngleAxis(angle, Camera.main.transform.forward);
        }

        else
        {
            if (!rotate_started)
            {
                //my_camera.rotate_start();
                rotate_started = true;
            }
            else
                Camera.main.transform.rotation = startOrientation * Quaternion.AngleAxis(-angle, Camera.main.transform.forward);
        }
    }

    public void rotateEnd()
    {
        rotate_started = false;
    }

    public void rotateStart()
    {
        // throw new System.NotImplementedException();
    }


    public void tap(Vector2 position)
    {

        Ray our_ray = Camera.main.ScreenPointToRay(position);
        Debug.DrawRay(our_ray.origin, our_ray.direction * 50, Color.red, 4f);
        RaycastHit hit_info;
        if (Physics.Raycast(our_ray, out hit_info))
        {
            IInteractable the_object = hit_info.transform.GetComponent<IInteractable>();

            if (selected_object != null)
                selected_object.select_toggle();


            selected_object = the_object;
            selected_object.select_toggle();


        }
        else
        {
            selected_object.select_toggle();
            selected_object = null;
        }
    }

    public void twoFingerDrag(Vector2 p)
    {
        if (selected_object == null)
        {

            if (!twoFinDrag)
            {
                twoFinDrag = true;

                cameraStarting = Camera.main.transform.rotation;
            }
            else
            {
                Camera.main.transform.rotation = Quaternion.AngleAxis(p.x, Camera.main.transform.up) * cameraStarting;
            }

        }
    }

}