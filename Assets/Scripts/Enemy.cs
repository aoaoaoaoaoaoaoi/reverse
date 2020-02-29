using System;
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
    private RectTransform enemyRect;
    private State currentState = State.Uzumaki;
    private bool isProgress = false;
    Action action;

    private enum State
    {
        None,
        Uzumaki,
        UzumakiRight,
        UzumakiLeft,
        UzumakiBoth,
    }

    private void Start()
    {
        enemyRect = this.gameObject.GetComponent<RectTransform>();
        action = () => isProgress = false;
    }

    private void Update()
    {
        if (isProgress) return;
        switch (currentState) {
            case State.Uzumaki:
                isProgress = true;
                var uzumaki = new Uzumaki(10f, 100f, 0.2f, 2f);
                StartCoroutine(uzumaki.MakeUzumaki(enemyRect, bulletCache, 4, action));
                currentState = State.UzumakiRight;
                break;
            case State.UzumakiRight:
                isProgress = true;
                var uzumakiKai = new UzumakiKai(10f, 100f, 0.1f, 1f, 5);
                StartCoroutine(uzumakiKai.MakeUzumakiKai(enemyRect, bulletCache, 3, action));
                currentState = State.UzumakiLeft;
                break;
            case State.UzumakiLeft:
                isProgress = true;
                var uzumakiLeft = new UzumakiKaiLeft(10f, 100f, 0.1f, 2f, 7);
                StartCoroutine(uzumakiLeft.MakeUzumakiKaiLeft(enemyRect, bulletCache, 4, action));
                currentState = State.UzumakiBoth;
                break;
            case State.UzumakiBoth:
                isProgress = true;
                var uzumakiBoth = new UzumakiKai();
                var uzumakiBothLeft = new UzumakiKaiLeft();
                StartCoroutine(uzumakiBoth.MakeUzumakiKai(this.gameObject.GetComponent<RectTransform>(), bulletCache, 3, action));
                StartCoroutine(uzumakiBothLeft.MakeUzumakiKaiLeft(this.gameObject.GetComponent<RectTransform>(), bulletCache, 14, action));
                currentState = State.None;
                break;
            case State.None:
                gameOver.gameObject.SetActive(true);
                player.isGameOver = true;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hpSlider.value += 0.0015f;
        score.AddScore(100);
        if(1.0f <= hpSlider.value)
        {
            gameOver.gameObject.SetActive(true);
            player.isGameOver = true;
        }
    }
}
