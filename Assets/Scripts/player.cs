using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject obj_javelin;

    Rigidbody rb;

    [SerializeField] float speed = 1000f;
    [SerializeField] float force = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        controls();
    }

    void controls()
    {
        float speed_x = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            print("<-");
            rb.AddForce(Vector3.left * speed_x);
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) {
            print("->");
            rb.AddForce(Vector3.right * speed_x);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            throwJavelin();
        }
    }

    void throwJavelin()
    {
        Vector3 p = transform.position;
        GameObject javelin = Instantiate(obj_javelin, new Vector3(p.x, p.y + .1f, p.z), Quaternion.Euler(0f, 0f, -45f));
        Rigidbody jav_rb = javelin.GetComponent<Rigidbody>();
        jav_rb.AddRelativeForce(Vector3.up * force, ForceMode.Impulse);
    }
}
    