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
    }

    private void Start()
    {
        var weapon = GetComponent<WeaponBase>();
        weapon.OnAttackEvent.AddListener(DrawAttackMesh);
    }

    private void DrawAttackMesh(AttackBase attack)
    {
        var stepDegrees = 5f;
        var attackData = attack.AttackData;

        var vertexList = CreateAreaPoints(
            _moveController.Direction, attackData.AttackRadius,
            attackData.AngleDegrees, stepDegrees);
        var triangleList = CreateTriangleIndexes(attackData.AngleDegrees / stepDegrees);
        var uvList = CreateUv(vertexList.Count);

        ResetMesh(vertexList, uvList, triangleList);

        StartCoroutine(DeleteMesh(attackData.DelayBeforeAttack));
    }

    private IEnumerator DeleteMesh(float delay)
    {
        yield return new WaitForSeconds(delay);
        _meshFilter.mesh.Clear(); 
    }

    private void ResetMesh(List<Vector3> vertexList, List<Vector2> uvList, List<int> triangleList)
    {
        _meshFilter.mesh.Clear();
        _meshFilter.mesh.vertices = vertexList.ToArray();
        _meshFilter.mesh.uv = uvList.ToArray();
        _meshFilter.mesh.triangles = triangleList.ToArray();
        _meshFilter.mesh.RecalculateNormals();
    }

    private List<Vector3> CreateAreaPoints(Vector2 direction, float radius, float angleDegrees, float stepDegrees)
    {
        var result = new List<Vector3> { Vector3.zero };
        var angle = angleDegrees * Mathf.Deg2Rad / 2;
        var step = stepDegrees * Mathf.Deg2Rad;
        var point = direction * radius;

        for (; angle + angleDegrees * Mathf.Deg2Rad / 2 + step > 1e-5; angle -= step)
            result.Add(point.Rotate(angle));

        return result;
    }

    private List<int> CreateTriangleIndexes(float triangleCount)
    {
        var triangleList = new List<int>();
        for (var i = 0; i < triangleCount; i++)
        {
            triangleList.Add(0);
            triangleList.Add(i + 1);
            triangleList.Add(i + 2);
        }

        return triangleList;
    }

    private List<Vector2> CreateUv(int count)
    {
        var uvList = new List<Vector2>();
        for (var i = 0; i < count; i++)
        {
            var x = (1.0f / count) * i;
            uvList.Add(new Vector2(x, 1));
        }

        return uvList;
    }
}
