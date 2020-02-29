using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] private RectTransform bulletRect;
    [SerializeField] private Rigidbody2D bulletRigidbody2D;
    [SerializeField] private Image enemyBulletImage;
    [SerializeField] private Image playerBulletImage;
    public RectTransform BulletRect => bulletRect;
    public Rigidbody2D BulletRigidbody2D => bulletRigidbody2D;
    private BulletCache bulletCache;
    private RectTransform background;

    public void Initialize(BulletCache bulletCache, RectTransform background)
    {
        this.bulletCache = bulletCache;
        this.background = background;
    }

    private void Update()
    {
        if(BulletRect.localPosition.x < -background.sizeDelta.x / 2 
            || background.sizeDelta.x / 2 < BulletRect.localPosition.x
            || BulletRect.localPosition.y < -background.sizeDelta.y / 2
            || background.sizeDelta.y / 2 < BulletRect.localPosition.y)
        {
            this.gameObject.SetActive(false);
            bulletRect.anchoredPosition = new Vector2(0, 0);
            bulletCache.ReturnBullet(this);
        }
    }

    public void SwitchBulletImage(bool isEnemy)
    {
        enemyBulletImage.gameObject.SetActive(isEnemy);
        playerBulletImage.gameObject.SetActive(!isEnemy);
    }
}
