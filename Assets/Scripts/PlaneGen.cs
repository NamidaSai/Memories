using UnityEngine;
using System.Collections;

// source: https://forum.unity.com/threads/random-2d-shape-generation.376836/

public class PlaneGen : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn = default;
    [SerializeField] Material spriteMaterial;
    [SerializeField] MemoryType[] memoryTypes = default;
    [SerializeField] int targetLayerIndex = 2;

    public void SpawnMemory()
    {
        Vector3 spawnLocation = transform.position;
        GameObject spawnedGameObject = Instantiate(prefabToSpawn, spawnLocation, Quaternion.identity) as GameObject;

        // Create a 2D plane procedurally on our new Object
        GeneratePlane(spawnedGameObject);

        // Assign sorting layer to behave as sprite
        SortingLayers3D sortingLayers = spawnedGameObject.AddComponent<SortingLayers3D>();
        sortingLayers.index = targetLayerIndex;

        // adjust Collider boundaries
        SetPolygonCollider3D.UpdatePolygonColliders(spawnedGameObject.transform);

        // assign memory type
        spawnedGameObject.GetComponent<Memory>().type = memoryTypes[Random.Range(0, memoryTypes.Length)];

        // randomise scale
        float targetScale = spawnedGameObject.GetComponent<Memory>().type.GetScale();
        spawnedGameObject.transform.localScale = new Vector3(targetScale, targetScale, 1f);

        // randomise weight
        float targetWeight = spawnedGameObject.GetComponent<Memory>().type.GetWeight();
        spawnedGameObject.GetComponent<Rigidbody2D>().mass = spawnedGameObject.GetComponent<Memory>().type.GetWeight();

        // randomise color
        Color targetColor = spawnedGameObject.GetComponent<Memory>().type.GetColor();
        spawnedGameObject.GetComponent<MeshRenderer>().material.SetColor("_MainColor", targetColor);
    }

    private void GeneratePlane(GameObject spawnedGameObject)
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