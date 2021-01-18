using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    BoxCollider2D box;
    Rigidbody2D rig;

    float width;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rig = GetComponent<Rigidbody2D>();

        rig.velocity = new Vector2(-GameController.instance.speed, 0f);
        width = box.size.x;
    }

    void Update()
    {
        if (GameController.instance.gameover)
        {
            rig.velocity = Vector2.zero;
        }

        if (transform.position.x < -width)
        {
            Vector2 position = new Vector2(width * 2, 0f);
            transform.position = (Vector2)transform.position + position;
        }
    }
}
