using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BulletCache bulletCache;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Score score;

    void Start()
    {
        var uzumaki = new Uzumaki();
        StartCoroutine(uzumaki.MakeUzumaki(this.gameObject.GetComponent<RectTransform>(), bulletCache, 100));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hpSlider.value += 0.001f;
        score.AddScore(100);
    }
}
