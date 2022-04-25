using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode up, down, left, right;
    float Vertical
    {
        get
        {
            float value = 0;
            if (Input.GetKey(up))
                value = 1;
            else if (Input.GetKey(down))
                value = -1;
            return value;
        }
    }
    float Horizontal
    {
        get
        {
            float value = 0;
            if (Input.GetKey(right))
                value = 1;
            else if (Input.GetKey(left))
                value = -1;
            return value;
        }
    }
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Horizontal, Vertical);
        rb.velocity = input * 10;
    }
}
