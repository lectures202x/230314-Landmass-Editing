using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    public int Worldx;
    public int Worldz;

    private Mesh mesh;

    private int[] triangles;
    private Vector3[] verticies;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        GenerateMesh();
        UpdateMesh();
        
    }

    // Update is called once per frame
    void GenerateMesh()
    {
        triangles = new int[Worldx * Worldz * 6];
        verticies = new Vector3[(Worldx + 1) * (Worldz + 1)];

        for (int i = 0, z = 0; z <= Worldz; z++)
        {
            for (int x = 0; x <= Worldx; x++)
            {
                verticies[i] = new Vector3(x, 0, z);
                i++;
            }
        }

        int tris = 0;
        int verts = 0;

        for (int z = 0; z < Worldz; z++)
        {
            for (int x = 0; x < Worldx; x++)
            {
                triangles[tris + 0] = verts + 0;
                triangles[tris + 1] = verts + Worldz + 1;
                triangles[tris + 2] = verts + 1;

                triangles[tris + 3] = verts + 1;
                triangles[tris + 4] = verts + Worldz + 1;
                triangles[tris + 5] = verts + Worldz + 2;

                verts++;
                tris += 6;
            }

            verts++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = triangles;
        
        mesh.RecalculateNormals();
    }
}
