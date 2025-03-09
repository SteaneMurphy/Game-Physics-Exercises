using UnityEngine;

public class RayCollision : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public LineRenderer lineRenderer;
    public Plane plane;

    void Start()
    {
        
    }

    void Update()
    {
        CreateRay();
    }

    private void CreateRay() 
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);

        //find direction vector
        Vector3 ray = endPosition - startPosition;

        //solve for t in plane equation
        float t = -((plane.planeNormal.x * startPosition.x) + (plane.planeNormal.y * startPosition.y) + (plane.planeNormal.z * startPosition.z) + plane.planeScalar)
                    / ((plane.planeNormal.x * ray.x) + (plane.planeNormal.y * ray.y) + (plane.planeNormal.z * ray.z));

        //if t is less than 0 or greater than 1, no intersection
        if (t < 0 || t > 1)
        {
            print("No intersection");
        }
        else if(t > 0 || t < 1) 
        {
            print($"Ray intersects the plane at point: {CalculateIntersectionPoint(t, startPosition, ray)}");
        }
        else if(t == 0) 
        {
            print("Ray is parrallel to the plane");
        }
    }

    private Vector3 CalculateIntersectionPoint(float t, Vector3 startPosition, Vector3 ray) 
    {
        return startPosition + t * ray;
    }
}
