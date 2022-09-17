using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class DrawArch : MonoBehaviour
{
    public float Radius = 20.0f; // ������ �������� ������
    public float Thickness = 10.0f; // �������, ������ �������� ����� ����� ������ ����������� �����
    public float Depth = 1.0f; // �������
    public float NumberOfSides = 30.0f; // ������� ��� ������� ��
    public float DrawArchDegrees = 90.0f; // ��� ����� ��������
    public Material archMaterial = null;

    private List<Vector3> vertexList = new List<Vector3>();
    private List<int> triangleList = new List<int>();
    private List<Vector2> uvList = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateVertex();
    }

    void GenerateVertex()
    {
        // ���������� �������
        vertexList.Clear();
        float incrementAngle = DrawArchDegrees / NumberOfSides;
        // ������ ��� �����, ������ ��� n + 1 ����� ����� ������������ n ������
        for (int i = 0; i <= NumberOfSides; i++)
        {
            float angle = 180 - i * incrementAngle;
            float innerX = (Radius - Thickness) * Mathf.Cos(angle * Mathf.Deg2Rad);
            float innerY = (Radius - Thickness) * Mathf.Sin(angle * Mathf.Deg2Rad);
            vertexList.Add(new Vector3(innerX, innerY, 0));
            float outsideX = Radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            float outsideY = Radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            vertexList.Add(new Vector3(outsideX, outsideY, 0));
        }

        // ������ ������������
        triangleList.Clear();
        int direction = 1;
        for (int i = 0; i < NumberOfSides * 2; i++)
        {
            int[] triangleIndexs = getTriangleIndexs(i, direction);
            direction *= -1;
            for (int j = 0; j < triangleIndexs.Length; j++)
            {
                triangleList.Add(triangleIndexs[j]);
            }
        }

        // ��-������
        uvList.Clear();
        for (int i = 0; i <= NumberOfSides; i++)
        {
            float angle = 180 - i * incrementAngle;
            float littleX = (1.0f / NumberOfSides) * i;
            uvList.Add(new Vector2(littleX, 0));
            float bigX = (1.0f / NumberOfSides) * i;
            uvList.Add(new Vector2(bigX, 1));
        }
        Mesh mesh = new Mesh()
        {
            vertices = vertexList.ToArray(),
            uv = uvList.ToArray(),
            triangles = triangleList.ToArray(),
        };

        mesh.RecalculateNormals();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = archMaterial;
    }

    int[] getTriangleIndexs(int index, int direction)
    {
        int[] triangleIndexs = new int[3] { 0, 1, 2 };
        for (int i = 0; i < triangleIndexs.Length; i++)
        {
            triangleIndexs[i] += index;
        }
        if (direction == -1)
        {
            int temp = triangleIndexs[0];
            triangleIndexs[0] = triangleIndexs[2];
            triangleIndexs[2] = temp;
        }
        return triangleIndexs;
    }
}
