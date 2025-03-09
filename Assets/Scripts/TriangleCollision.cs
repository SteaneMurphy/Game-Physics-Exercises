using UnityEngine;

public class TriangleCollision : MonoBehaviour
{
    private Mesh mesh;
    public Vector3 vertice1;
    public Vector3 vertice2;
    public Vector3 vertice3;


    void Start()
    {
        mesh = new Mesh();
    }

    // Update is called once per frame
    void Update()
    {
        DrawTriangle();
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
}
