using UnityEngine;

public static class VectorExtension
{
    private static readonly float _isometricAngle = -Mathf.Sqrt(5) / 5;

    public static Vector2 Rotate(this Vector2 vector, float angle)
    {
        var x = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        var y = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);

        return new Vector2(x, y);
    }

    public static Vector2 RotateToIsometric(this Vector2 vector)
    {
        return Rotate(vector, _isometricAngle);
    }

    public static Vector3 Rotate(this Vector3 vector, float angle)
    {
        var x = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        var y = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);

        return new Vector3(x, y);
    }

    public static Vector3 RotateToIsometric(this Vector3 vector)
    {
        return Rotate(vector, _isometricAngle);
    }
}
