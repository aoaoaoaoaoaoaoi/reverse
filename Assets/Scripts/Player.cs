using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private RectTransform playerRect;
    private readonly float moveDistance = 5f;

    private void Start()
    {
        playerRect = this.GetComponent<RectTransform>();
    }
    
    private void Update()
    {
        Move();
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
}
