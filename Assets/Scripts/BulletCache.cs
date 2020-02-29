using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BulletCache : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
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
            return bulletStack.Pop();
        }
        return MakeBullet();
    }

    private Bullet MakeBullet()
    {
        return Instantiate(bullet, this.gameObject.transform);
    }

    public void ReturnBullet(IEnumerable<Bullet> bulletList)
    {
        foreach (var bullet in bulletList)
        {
            bulletStack.Push(bullet);
        }
    }
}
