using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class javelin : MonoBehaviour
{
    GameObject player;

    Rigidbody rb;

    Transform t_player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = GameObject.Find("obj_player");
        t_player = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        motion();
        controls();
    }

    void controls()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            rb.Sleep();
        }
    }

    void motion()
    {
        Vector3 direction = rb.velocity.normalized;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case SD.PLAYER_TAG:
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }
}
