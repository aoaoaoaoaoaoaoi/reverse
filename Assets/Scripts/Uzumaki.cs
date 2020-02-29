using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uzumaki
{
    private readonly float fullAngle = 360f;
    private float degInterval;
    private float radius;
    private float makeInterval;
    private float speed;

    public Uzumaki(float degInterval = 30f, float radius = 100f, float makeInteval = 0.5f, float speed = 2f)
    {
        this.degInterval = degInterval;
        this.radius = radius;
        this.makeInterval = makeInterval;
        this.speed = speed;
    }

    public IEnumerator MakeUzumaki(RectTransform center, BulletCache cache, int times)
    {
        for(int i = 0;i < times; i++){
            var deg = 0f;
            while (deg < fullAngle)
            {
                var rad = deg * Mathf.Deg2Rad;
                var cos = Mathf.Cos(rad);
                var sin = Mathf.Sin(rad);
                var bullet = cache.GetBullet();
                bullet.BulletRect.anchoredPosition = new Vector2(center.anchoredPosition.x + radius * cos, center.anchoredPosition.y + radius * sin);
                bullet.BulletRigidbody2D.velocity = (bullet.BulletRect.anchoredPosition - center.anchoredPosition).normalized * speed;
                deg += degInterval;
                yield return new WaitForSeconds(makeInterval);
            }
        }
    }
}
