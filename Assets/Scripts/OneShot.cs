using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShot
{
    private readonly float centerDistance = 40f;
    private float speed;
    private float distanceInterval;
    private int times;

    public OneShot(float speed = 4f, float distanceInterval = 35f, int times = 5)
    {
        this.speed = speed;
        this.distanceInterval = distanceInterval;
        this.times = times;
    }

    public void MakeOneShot(RectTransform center, BulletCache cache)
    {
        float targetPoint;
        if (times % 2 == 0)
        {
            var half = times / 2;
            targetPoint = center.anchoredPosition.x - (distanceInterval / 2 + distanceInterval * (half - 1));
        }
        else
        {
            var half = (times - 1) / 2;
            targetPoint = center.anchoredPosition.x - (distanceInterval * half);
        }
        var bulletList = new List<Bullet>();
        for (int i = 0; i < times; ++i)
        {
            var bullet = cache.GetBullet();
            bullet.SwitchBulletImage(false);
            bullet.BulletRect.anchoredPosition = new Vector2(targetPoint, center.anchoredPosition.y + centerDistance);
            targetPoint += distanceInterval;
            bulletList.Add(bullet);
        }
        foreach (var bullet in bulletList)
        {
            bullet.BulletRigidbody2D.velocity = Vector2.up * speed;
        }
    }
}
