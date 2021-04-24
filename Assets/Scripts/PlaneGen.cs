using UnityEngine;
using System.Collections;

public class PlaneGen : MonoBehaviour
{

    public Material spriteMaterial;

    void Start()
    {

        //Create a new GameObject named "Spawned GameObject (Plane)"
        GameObject spawnedGameObject = new GameObject("Spawned GameObject (Plane)");

        //Create a 2D plane procedurally on our new Object
        GeneratePlane(spawnedGameObject);

    }


    void GeneratePlane(GameObject spawnedGameObject)
    {
        // You can change that line to provide another MeshFilter
        MeshFilter filter = spawnedGameObject.AddComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        mesh.Clear();

        float length = 1f;
        float width = 1f;
        int resX = 2; // 2 minimum
        int resY = 2;

        #region Vertices      
        Vector3[] vertices = new Vector3[resX * resY];
        for (int y = 0; y < resY; y++)
        {
            // [ -length / 2, length / 2 ]
            float yPos = ((float)y / (resY - 1) - .5f) * length;
            for (int x = 0; x < resX; x++)
            {
                // [ -width / 2, width / 2 ]
                float xPos = ((float)x / (resX - 1) - .5f) * width;
                vertices[x + y * resX] = new Vector3(xPos + Random.Range(-0.5f, 0.5f), yPos + Random.Range(-0.5f, 0.5f), 0.0f);

            }
        }
        #endregion

        #region Normales
        Vector3[] normales = new Vector3[vertices.Length];
        for (int n = 0; n < normales.Length; n++)
            normales[n] = -Vector3.forward;
        #endregion

        #region UVs      
        Vector2[] uvs = new Vector2[vertices.Length];
        for (int v = 0; v < resY; v++)
        {
            for (int u = 0; u < resX; u++)
            {
                uvs[u + v * resX] = new Vector2((float)u / (resX - 1), (float)v / (resY - 1));
            }
        }
        #endregion

        #region Triangles
        int nbFaces = (resX - 1) * (resY - 1);
        int[] triangles = new int[nbFaces * 6];
        int t = 0;
        for (int face = 0; face < nbFaces; face++)
        {
            // Retrieve lower left corner from face ind
            int i = face % (resX - 1) + (face / (resY - 1) * resX);

            triangles[t++] = i + resX;
            triangles[t++] = i + 1;
            triangles[t++] = i;

            triangles[t++] = i + resX;
            triangles[t++] = i + resX + 1;
            triangles[t++] = i + 1;
        }
        #endregion

        mesh.vertices = vertices;
        mesh.normals = normales;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.Optimize();


        //Attach material
        MeshRenderer rend = spawnedGameObject.AddComponent<MeshRenderer>();

        if (spriteMaterial)
        {
            rend.material = spriteMaterial;
        }
    }
}