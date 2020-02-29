using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BulletCache bulletCache;

    void Start()
    {
        var uzumaki = new Uzumaki();
        StartCoroutine(uzumaki.MakeUzumaki(this.gameObject.GetComponent<RectTransform>(), bulletCache, 1));
    }
    
    void Update()
    {
        
    }
}
