using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private RectTransform bulletRect;
    [SerializeField] private Rigidbody2D bulletRigidbody2D;
    public RectTransform BulletRect => bulletRect;
    public Rigidbody2D BulletRigidbody2D => bulletRigidbody2D;
}
