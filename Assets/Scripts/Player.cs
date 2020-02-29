using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Hp hp;
    [SerializeField] private BulletCache bulletCache;
    private readonly float shotInterval = 0.2f;
    private float currentShotTime = 0f;
    private RectTransform playerRect;
    private readonly float moveDistance = 5f;
    private OneShot oneShot;

    private void Start()
    {
        playerRect = this.GetComponent<RectTransform>();
        oneShot = new OneShot();
    }
    
    private void Update()
    {
        Move();
        Shot();
    }

    private void Move()
    {
        var newX = playerRect.localPosition.x;
        var newY = playerRect.localPosition.y;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newY += moveDistance;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            newY -= moveDistance;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            newX += moveDistance;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            newX -= moveDistance;
        }
        playerRect.anchoredPosition = new Vector2(newX, newY);
    }

    private void Shot()
    {
        currentShotTime += Time.deltaTime;
        if(shotInterval < currentShotTime)
        {
            if (Input.GetKey(KeyCode.W))
            {
                currentShotTime = 0f;
                oneShot.MakeOneShot(playerRect, bulletCache);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            
        }
        hp.Subtract();
    }
}
