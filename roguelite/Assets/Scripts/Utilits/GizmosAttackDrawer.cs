using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class GizmosAttackDrawer : MonoBehaviour
{
    private Vector2 _direction;
    private float _angle;
    private bool _isDraw;

    public void DrawAttack(AttackBase attack)
    {
        var angle = 360f;
        var value = attack.GetType().GetField("_attackAngleDegrees", BindingFlags.NonPublic | BindingFlags.Instance)
            ?.GetValue(attack);
        if (value != null)
            angle = (float)value;

        _direction = attack.GetComponentInParent<MoveController>().Direction;
        _angle = angle;
        _isDraw = true;
        StartCoroutine(Deactivate(attack.AttackData.DelayBeforeAttack));
    }

    private void DrawPolygon(Vector2 center, Vector2 direction, float angle)
    {
        var points = CreateCirclePoints(center, direction, 5).Where(point => Vector2.Angle(direction, point - center) <= angle / 2 ).ToList();
        
        for (var i = 0; i < points.Count - 1; i++)
            Gizmos.DrawLine(points[i], points[i + 1]);
        Gizmos.DrawLine(points[points.Count - 1], points[0]);
    }

    private List<Vector2> CreateCirclePoints(Vector2 center, Vector2 direction, float stepDegrees)
    {
        var result = new List<Vector2>();
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
        // p'x = cos(theta) * (px-ox) - sin(theta) * (py-oy) + ox
        // p'y = sin(theta) * (px-ox) + cos(theta) * (py-oy) + oy

        return result;
    }

    private void OnDrawGizmos()
    {
        if (_isDraw)
            DrawPolygon(transform.position, _direction, _angle);
    }

    private IEnumerator Deactivate(float time)
    {
        yield return new WaitForSeconds(time);
        _isDraw = false;
    }
}
