using UnityEngine;

public interface ITouchController
{
    void tap(Vector2 position);

    void drag(Vector2 current_position);

    void dragEnd();

    void pinch(float startDistance, float endDistance, float relDistance);
    void pinchEnd();
    void rotate(float new_angle);
    void rotateStart();
    void rotateEnd();
    void twoFingerDrag(Vector2 p);
}
