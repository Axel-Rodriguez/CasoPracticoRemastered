using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject rock, power, fly, die, player;
    private float speed = 2.5f, time = 2.0f, time2 = 1.21f;
    private float timer, timer2, direction = 1, direction2 = 1;

    void Start()
    {
        timer = 1.0f;
        timer2 = 1.0f;
    }

    private void FixedUpdate()
    {
        Vector2 positionP = player.GetComponent<Transform>().position;
        Vector2 positionY1 = rock.GetComponent<Transform>().position;
        Vector2 positionY2 = power.GetComponent<Transform>().position;
        Vector2 positionY3 = fly.GetComponent<Transform>().position;
        Vector2 positionY4 = die.GetComponent<Transform>().position;
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        float offset = 1.44f;
        if (timer < 0)
        {
            timer = time;
            direction *= -1;
        }
        if(direction > 0)
        {
            positionP.x -= speed * Time.deltaTime;
        }
        else
        {
            positionP.x += speed * Time.deltaTime;
        }
        if(direction2 > 0)
        {
            positionY1.y -= (speed - offset) * Time.deltaTime;
            positionY2.y -= (speed - offset) * Time.deltaTime;
            positionY3.y -= (speed - offset) * Time.deltaTime;
            positionY4.y -= (speed - offset) * Time.deltaTime;
        }
        else
        {
            positionY1.y += (speed - offset) * Time.deltaTime;
            positionY2.y += (speed - offset) * Time.deltaTime;
            positionY3.y += (speed - offset) * Time.deltaTime;
            positionY4.y += (speed - offset) * Time.deltaTime;
        }
        if (timer2 < 0)
        {
            timer2 = time2;
            direction2 *= -1;
        }
        else
        {
            rock.GetComponent<Rigidbody>().MovePosition(positionY1);
            power.GetComponent<Rigidbody>().MovePosition(positionY2);
            fly.GetComponent<Rigidbody>().MovePosition(positionY3);
            die.GetComponent<Rigidbody>().MovePosition(positionY4);
        }
        player.GetComponent<Rigidbody>().MovePosition(positionP);
    }
}
