using UnityEngine;

public class Plane : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public MeshRenderer meshRenderer;
    private Bounds bounds;
    public float width;
    public float length;
    public Vector3 planeNormal;
    public float planeScalar;


    void Start()
    {
        bounds = meshRenderer.bounds;
    }

    void Update()
    {
        DrawPlaneNormal();
    }

    private void DrawPlaneNormal() 
    {
        width = bounds.size.x;
        length = bounds.size.z;
        Transform planeTransform = GetComponent<Transform>();

        //vertices are calculated locally and then corrected for rotation
        //bottom-left vertice
        Vector3 p1 = new Vector3(bounds.min.x, transform.position.y, bounds.min.z);
        Vector3 worldp1 = planeTransform.TransformPoint(p1);
        //top-left vertice
        Vector3 p2 = new Vector3(bounds.min.x, transform.position.y, bounds.max.z);
        Vector3 worldp2 = planeTransform.TransformPoint(p2);
        //top-right vertice
        Vector3 p3 = new Vector3(bounds.max.x, transform.position.y, bounds.max.z);
        Vector3 worldp3 = planeTransform.TransformPoint(p3);

        //Vectors from bottom-left to top-right
        Vector3 v1 = worldp2 - worldp1;
        Vector3 v2 = worldp3 - worldp2;

        //cross product to find normal vector (normalised)
        planeNormal = (Vector3.Cross(v1, v2)).normalized;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, planeNormal);

        SetPlaneScalar(p1);
    }

    private void SetPlaneScalar(Vector3 p1) 
    {
        planeScalar = -Vector3.Dot(planeNormal, p1);
    }
}
