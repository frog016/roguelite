using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(WeaponBase))]
public class AttackAreaDrawer : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private MoveController _moveController;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = new Mesh();
        _moveController = GetComponentInParent<MoveController>();
        //GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
    }

    private void Start()
    {
        var weapon = GetComponent<WeaponBase>();
        weapon.OnAttackEvent.AddListener(DrawAttackMesh);
    }

    private void DrawAttackMesh(AttackData attackData)
    {
        var angle = attackData.AngleDegrees;

        var mesh = _meshFilter.mesh;
        mesh.Clear();
        var vertexes = CreateCirclePoints(transform.position, _moveController.Direction, 5f)
            .Where(point => Vector2.Angle(_moveController.Direction, point - transform.position) <= angle / 2).ToList();
        vertexes.Add(transform.position);

        mesh.vertices = vertexes.ToArray();
        mesh.triangles = CreateTriangles(vertexes).ToArray();

        var normals = new List<Vector3>();
        for (var i = 0; i < vertexes.Count; i++)
            normals.Add(-transform.forward);
        mesh.normals = normals.ToArray();

        mesh.uv = vertexes.Select(vertex => new Vector2(vertex.x, vertex.y)).ToArray();

        _meshFilter.mesh = mesh;
        //StartCoroutine(DeleteMesh(attackData.DelayBeforeAttack));
    }

    private IEnumerator DeleteMesh(float delay)
    {
        yield return new WaitForSeconds(delay);
        _meshFilter.mesh.Clear(); 
    }

    private List<Vector3> CreateCirclePoints(Vector2 center, Vector2 direction, float stepDegrees)
    {
        var result = new List<Vector3>();
        var point = center - direction;
        var step = stepDegrees * Mathf.PI / 180;
        var angle = step;
        result.Add(point);

        for (var i = 0; i < 360 / stepDegrees; i++)
        {
            var x = Mathf.Cos(angle) * (point.x - center.x) - Mathf.Sin(angle) * (point.y - center.y) + center.x;
            var y = Mathf.Sin(angle) * (point.x - center.x) + Mathf.Cos(angle) * (point.y - center.y) + center.y;
            result.Add(new Vector2(x, y));
            angle += step;
        }

        return result;
    }

    private List<int> CreateTriangles(List<Vector3> vertexes)
    {
        var trianglesIndexes = new List<int>();

        for (var i = 0; i < vertexes.Count - 2; i += 2)
        {
            trianglesIndexes.Add(vertexes.Count - 1);
            trianglesIndexes.Add(i);
            trianglesIndexes.Add(i + 1);
        }

        return trianglesIndexes;
    }
}
