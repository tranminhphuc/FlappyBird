using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public float jumpForce;

    Rigidbody2D rig;
    Animator anim;

    bool die = false;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
#if UNITY_ANDROID

        if (!die)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    anim.SetTrigger("Flap");
                    rig.velocity = Vector2.zero;
                    rig.AddForce(new Vector2(0, jumpForce));
                }
            }
        }
#endif
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        die = true;
        rig.velocity = Vector2.zero;
        anim.SetTrigger("Die");
        GameController.instance.Die();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CheckPoint")
        {
            GameController.instance.AddScore();
        }
    }
}
