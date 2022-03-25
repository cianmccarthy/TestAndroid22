using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{

    void dragStart();
    void dragEnd();
    void select_toggle();
    void dragUpdate(Ray r);
    void dragActivated(Ray ray, float destination);
    GameObject gameObject { get; }

}