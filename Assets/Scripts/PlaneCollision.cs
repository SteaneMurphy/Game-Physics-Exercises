using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Plane plane;
    public MeshRenderer planeRenderer;
    private Bounds planeBounds;

    void Update()
    {
        //dot product to determine if point is in front, behind or touching the plane
        //plane equation method to find the dot product
        float dotProduct = (plane.planeNormal.x * transform.position.x) + (plane.planeNormal.y * transform.position.y) + 
                           (plane.planeNormal.z * transform.position.z);

        if (dotProduct > 0f)
        {
            print($"Point lies in front of plane - Dot Product: {dotProduct}");
        }
        else if (dotProduct < 0f) 
        {
            print($"Point lies behind the plane - Dot Product: {dotProduct}");
        }
        else if (dotProduct == 0f)
        {
            planeBounds = planeRenderer.bounds;
            float clampedX = Mathf.Clamp(transform.position.x, planeBounds.min.x, planeBounds.max.x);
            float clampedZ = Mathf.Clamp(transform.position.z, planeBounds.min.z, planeBounds.max.z);

            if (transform.position.x != clampedX || transform.position.z != clampedZ)
            {
                print($"The point is inline with the plane but outside of its dimensions");
            }
            else 
            {
                print($"Point is colliding with the plane - Dot Product: {dotProduct}");
            }
        }
    }
}
