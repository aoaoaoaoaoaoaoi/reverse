using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private RectTransform playerRect;
    private readonly float moveDistance = 5f;
    // Start is called before the first frame update
    private void Start()
    {
        playerRect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRect.anchoredPosition = new Vector2(playerRect.localPosition.x, playerRect.localPosition.y + moveDistance);
        }
    }
}
