using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BulletCache bulletCache;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Score score;
    [SerializeField] private Player player;
    [SerializeField] private Image gameOver;

    void Start()
    {
        var uzumaki = new UzumakiKai();
        var uzumakiLeft = new UzumakiKaiLeft();
        StartCoroutine(uzumaki.MakeUzumakiKai(this.gameObject.GetComponent<RectTransform>(), bulletCache, 100));
        StartCoroutine(uzumakiLeft.MakeUzumakiKaiLeft(this.gameObject.GetComponent<RectTransform>(), bulletCache, 100));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hpSlider.value += 0.003f;
        score.AddScore(100);
        if(1.0f <= hpSlider.value)
        {
            gameOver.gameObject.SetActive(true);
            player.isGameOver = true;
        }
    }
}
