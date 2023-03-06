using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 SetX(this Vector3 vector, float x)
    {
        Vector3 tmp = vector;
        tmp.x = x;
        vector = tmp;
        return vector;
    }
    public static Vector3 SetY(this Vector3 vector, float y)
    {
        Vector3 tmp = vector;
        tmp.y = y;
        vector = tmp;
        return vector;
    }
    public static Vector3 SetZ(this Vector3 vector, float z)
    {
        Vector3 tmp = vector;
        tmp.z = z;
        vector = tmp;
        return vector;
    }
    public static Vector3 AddX(this Vector3 vector, float xDelta)
    {
        Vector3 tmp = vector;
        tmp.x = tmp.x + xDelta;
        vector = tmp;
        return vector;
    }
    public static Vector3 AddY(this Vector3 vector, float yDelta)
    {
        Vector3 tmp = vector;
        tmp.y = tmp.y + yDelta;
        vector = tmp;
        return vector;
    }
    public static Vector3 AddZ(this Vector3 vector, float zDelta)
    {
        Vector3 tmp = vector;
        tmp.z = tmp.z + zDelta;
        vector = tmp;
        return vector;
    }
}