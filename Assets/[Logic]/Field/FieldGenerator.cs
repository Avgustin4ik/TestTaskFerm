using System;
using System.Linq;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int size;
    [SerializeField] private Cell cellPrefab;
    private MeshFilter _meshFilter;


    public void Awake()
    {
        Generate();
    }

    public void Generate()
    {
        var localPosition = transform.position;
        _meshFilter = cellPrefab.GetComponent<MeshFilter>();
        var offset = CalculateCellMeshBorder(_meshFilter.sharedMesh);
        for (int i = size.y - 1; i >= 0; i--)
        {
            for (int j = size.x - 1; j >= 0; j--)
            {
                var position = localPosition + Vector3.Scale(offset,
                    new Vector3(-size.x / 2 + j, 1, -size.y / 2 + i));
                Instantiate(cellPrefab, position, Quaternion.identity);
            }
        }
    }

    private Vector3 CalculateCellMeshBorder(Mesh mesh)
    {
        var vertices = mesh.vertices;
        var sortedVertices = vertices
            .OrderBy(v => v.x)
            .ThenBy(v => v.y)
            .ThenBy(v => v.z);
        return sortedVertices.First() - sortedVertices.Last();
    }

    private void OnDrawGizmos() //как быдло
    {
        var localPosition = transform.position;
        _meshFilter = cellPrefab.GetComponent<MeshFilter>();
        var offset = CalculateCellMeshBorder(_meshFilter.sharedMesh);

        for (int i = 0; i < size.y; i++)
        {
            for (int j = 0; j < size.x; j++)
            {
                var position = localPosition + Vector3.Scale(offset,
                    new Vector3(-size.x / 2 + j, 1, -size.y / 2 + i)) + Vector3.up*0.25f;
                Gizmos.DrawWireMesh(_meshFilter.sharedMesh,position,Quaternion.identity);
            }
        }
    }
}
