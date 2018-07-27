using UnityEngine;

public static class GameUtils
{
    public static Vector3 CreatePositionInCircle (Vector3 center, float minRadius, float maxRadius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + Random.Range(minRadius, maxRadius) * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = 5;
        pos.z = center.y + Random.Range(minRadius, maxRadius) * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
