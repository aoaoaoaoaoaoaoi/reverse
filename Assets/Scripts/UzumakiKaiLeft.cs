using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzumakiKaiLeft : UzumakiKai
{
    public UzumakiKaiLeft(float degInterval = 10f, float radius = 100f, float makeInterval = 0.02f, float speed = 5f, int count = 4)
    {
        this.degInterval = degInterval;
        this.radius = radius;
        this.makeInterval = makeInterval;
        this.speed = speed;
        this.count = count;
    }

    public IEnumerator MakeUzumakiKaiLeft(RectTransform center, BulletCache cache, int times, Action action)
    {
        for (int i = 0; i < times; i++)
        {
            var deg = fullAngle;
            while (0 < deg)
            {
                for (int j = 0; j < count; ++j)
                {
                    var rad = (deg - (fullAngle / count) * j) * Mathf.Deg2Rad;
                    var cos = Mathf.Cos(rad);
                    var sin = Mathf.Sin(rad);
                    var bullet = cache.GetBullet();
                    bullet.SwitchBulletImage(true);
                    bullet.BulletRect.anchoredPosition = new Vector2(center.anchoredPosition.x + radius * cos, center.anchoredPosition.y + radius * sin);
                    bullet.BulletRigidbody2D.velocity = (bullet.BulletRect.anchoredPosition - center.anchoredPosition).normalized * speed;
                }
                deg -= degInterval;
                yield return new WaitForSeconds(makeInterval);
            }
        }
        action?.Invoke();
    }
}
