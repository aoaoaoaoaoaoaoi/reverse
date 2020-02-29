using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BulletCache : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private RectTransform background;
    public Stack<Bullet> bulletStack = new Stack<Bullet>();
    private Transform bulletRoot;

    private void Start()
    {
        bulletRoot = this.gameObject.transform;
    }

    public Bullet GetBullet()
    {
        if(bulletStack.Any())
        {
            var bullet = bulletStack.Pop();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        return MakeBullet();
    }

    private Bullet MakeBullet()
    {
        var newBullet = Instantiate(bullet, this.gameObject.transform);
        newBullet.Initialize(this, background);
        return newBullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        if(bulletStack.Count() < 100)
        {
            bulletStack.Push(bullet);
        }
        else
        {
            Destroy(bullet.gameObject);
            bullet = null;
        }
    }
}
