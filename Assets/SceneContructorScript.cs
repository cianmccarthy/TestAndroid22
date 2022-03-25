using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneConstructorScript : MonoBehaviour
{

    GameObject cube;
    GameObject capsule;
    GameObject sphere;
    GameObject plane;

    GameObject touchManager;
    GameObject gestureIndentifier;
    
    // Start is called before the first frame update
    void Start()
    {

        touchManager = new GameObject("TouchManager");
        touchManager.AddComponent<SampleTouchManagerScript>();
        
        gestureIndentifier = new GameObject("GestureIdentifier");
        gestureIndentifier.AddComponent<GestureIdentifierScript>();

        Camera.main.transform.position = new Vector3(0f, 1f, -10f);

        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.layer = LayerMask.NameToLayer("Ground");
        plane.transform.position = new Vector3(-0.64f, -1.11f, 9.38f);
        plane.transform.localScale = new Vector3(3f, 3f, 3f);

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(-0.79f, 0.47f, 0f);
        cube.transform.localScale = new Vector3(1f, 1f, 1f);
        cube.AddComponent<CubeControl>();

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(5.69f, 0.88f, 2.5f);
        cube.transform.localScale = new Vector3(1f, 1f, 1f);
        cube.AddComponent<CubeControl>();

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(-2.43f, 0.44f, -4.982455f);
        cube.transform.localScale = new Vector3(1f, 1f, 1f);
        cube.AddComponent<CubeControl>();

        capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.transform.position = new Vector3(1.32f, 0.35f, 1.23f);
        capsule.transform.localScale = new Vector3(1f, 1f, 1f);
        capsule.AddComponent<CapsuleControlScript>();
        
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(3.65f, -0.05f, -3.05f);
        sphere.transform.localScale = new Vector3(1f, 1f, 1f);
        sphere.AddComponent<SphereControlScript>();

        
    }

    // Update is called once per frame
    void Update()
    {

    }

}