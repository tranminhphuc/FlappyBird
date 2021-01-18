using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col : MonoBehaviour
{
    public float offset;

    Rigidbody2D rig;
    float cameraWidth;

    void Start()
    {
        cameraWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;
    }

    void OnEnable()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(-GameController.instance.speed, 0f);
    }

    void Update()
    {
        if(GameController.instance.gameover)
        {
            rig.velocity = Vector2.zero;
        }

        if(transform.position.x < Camera.main.transform.position.x - cameraWidth / 2 - offset)
        {
            gameObject.SetActive(false);
        }
    }
}