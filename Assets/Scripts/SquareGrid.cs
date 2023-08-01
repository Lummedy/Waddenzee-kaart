using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SquareGrid : MonoBehaviour
{
    private Mesh mesh;
    public int xSize, ySize;
    // Start is called before the first frame update

    private void Awake()
    {
        Generate();
    }

    //vector used for the grid
    private Vector3[] vertices;

    private void Generate()
    {
        

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";

        //creates the vector used for the grid
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        Vector2[] uv = new Vector2[vertices.Length];
        //double loop to get the positions of the vertices
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2((float) x / xSize, (float) y / ySize);
                
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;

        int[] triangles = new int[xSize * ySize * 6];
        //loop that goes up
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
            //loop that goes sideways
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
                mesh.triangles = triangles;
                mesh.RecalculateNormals();
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        //makes sure we are in play mode (gizmos also invoke in edit mode)
        if (vertices == null)
        {
            return;
        }

        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }

    
}
