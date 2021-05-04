using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsController : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed = 2.0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position.y = position.y - speed * Time.deltaTime;
        if (position.y < -5)
        {
            Destroy(gameObject);
        }
        else
        {
            rigidbody.MovePosition(position);
        }
    }
}
