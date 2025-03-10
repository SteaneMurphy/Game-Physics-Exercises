using UnityEngine;

public class TriangleCollision : MonoBehaviour
{
    private Mesh mesh;
    public Vector3 vertice1;
    public Vector3 vertice2;
    public Vector3 vertice3;
    public Plane plane;


    void Start()
    {
        mesh = new Mesh();
    }

    void Update()
    {
        DrawTriangle();
        CheckForIntersection();
    }

    private void DrawTriangle ()
    {
        //Triangle vertices
        Vector3[] vertices = new Vector3[3];
        vertices[0] = vertice1;
        vertices[1] = vertice2;
        vertices[2] = vertice3;

        //Triangle array for the mesh triangle property
        int[] triangles = new int[3];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        //UVs for texturing
        Vector2[] uvs = new Vector2[3];
        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(1, 0);
        uvs[2] = new Vector2(0, 1);

        //Assign mesh properties
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }

    private void CheckForIntersection() 
    {
        //create three vectors that make up the triangle and test
        //each ray against an intersection against the plane
        Vector3 ray1 = vertice2 - vertice1;
        Vector3 ray2 = vertice3 - vertice2;
        Vector3 ray3 = vertice1 - vertice3;

        //solve for t in plane equation
        float ray1intersect = SolveForT(vertice1, ray1);
        float ray2intersect = SolveForT(vertice2, ray2);
        float ray3intersect = SolveForT(vertice3, ray3);

        CalculateIntersectionPoint(ray1intersect, vertice1, ray1);
        CalculateIntersectionPoint(ray2intersect, vertice2, ray2);
        CalculateIntersectionPoint(ray3intersect, vertice3, ray3);
    }

    private float SolveForT(Vector3 startPosition, Vector3 ray) 
    {
        return -((plane.planeNormal.x * startPosition.x) + (plane.planeNormal.y * startPosition.y) + (plane.planeNormal.z * startPosition.z) + plane.planeScalar)
                    / ((plane.planeNormal.x * ray.x) + (plane.planeNormal.y * ray.y) + (plane.planeNormal.z * ray.z));
    }

    private void CalculateIntersectionPoint(float t, Vector3 startPosition, Vector3 ray)
    {
        //if t is less than 0 or greater than 1, no intersection
        if (t < 0 || t > 1)
        {
            return;
        }
        else if (t > 0 || t < 1)
        {
            print($"Triangle intersects plane at: {startPosition + t * ray}");
        }
        return;
    }
}
