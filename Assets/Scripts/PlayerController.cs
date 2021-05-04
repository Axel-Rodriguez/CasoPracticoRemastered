using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    float horizontal, vertical;
    public float speed = 5.0f;
    private bool size = false, fly = false;
    AudioSource audio;
    public AudioClip audioRock, audioPower, audioFly, audioDie;
    private Coroutine powerC = null, flyC = null; 

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        speed = 5.0f;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;

        if (!fly)
        {
            if (position.x < 7.87 && position.x > -7.87 && !size)
            {
                rigidbody.MovePosition(position);
            }
            else if (position.x < 6.86 && position.x > -6.86 && size)
            {
                rigidbody.MovePosition(position);
            }
            else if (position.x > 7 && size)
            {
                rigidbody.transform.position = new Vector3(6.86f, -3.25f, 1);
            }
            else if (position.x < -7 && size)
            {
                rigidbody.transform.position = new Vector3(-6.86f, -3.25f, 1);
            }
        }
        else
        {
            position.y = position.y + vertical * speed * Time.deltaTime;
            if (position.x < 8.35 && position.x > -8.35 && position.y < 4.95 && position.y > -2.95 && !size)
            {
                rigidbody.MovePosition(position);
            }
            else if (position.x < 8.35 && position.x > -8.35 && position.y < 3.95 && position.y > -1.95 && size)
            {
                rigidbody.MovePosition(position);
            }
            else if (position.y > 3.95 && size)
            {
                rigidbody.transform.position = new Vector3(gameObject.transform.position.x, 3.85f, 1);
            }
            else if (position.y < -1.95 && size)
            {
                rigidbody.transform.position = new Vector3(gameObject.transform.position.x, -1.85f, 1);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        GameObject canvas = GameObject.Find("Canvas");
        if (tag == "Rock")
        {
            audio.PlayOneShot(audioRock, 1.0f);
            Destroy(other.gameObject);
            canvas.GetComponent<Score>().ScoreUpdate();
        }
        else if (tag == "Power")
        {
            audio.PlayOneShot(audioPower, 1.0f);
            canvas.GetComponent<Score>().count();
            Destroy(other.gameObject);
            size = true;
            speed += 0.75f;
            Vector3 scale = new Vector3(4, 1, 1);
            rigidbody.transform.localScale = scale;
            if (powerC != null)
            {
                StopCoroutine(powerC);                
            }
            powerC = StartCoroutine(ReverseScale());
        }
        else if(tag == "Fly")
        {
            audio.PlayOneShot(audioFly, 1.0f);
            canvas.GetComponent<Score>().count();
            Destroy(other.gameObject);
            fly = true;
            speed += 1.5f;
            rigidbody.transform.rotation = Quaternion.Euler(0, 0, 90);
            if (!size)
            {
                rigidbody.transform.position = new Vector3(gameObject.transform.position.x, -2.82f, 1);
            }
            else if(fly && size && !size){
                rigidbody.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1);
            }
            else if(size)
            {
                rigidbody.transform.position = new Vector3(gameObject.transform.position.x, -1.81f, 1);
            }
            if(flyC != null)
            {
                StopCoroutine(flyC);
            }
            flyC = StartCoroutine(ReverseFly());
        }
        else if(tag == "Die")
        {
            Destroy(other.gameObject);
            speed = 0;
            GameObject.Find("Spawner").SetActive(false);
            canvas.GetComponent<Score>().StopAllCoroutines();
            if (GameObject.FindGameObjectWithTag("Rock") != null)
            {
                GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock");
                foreach(GameObject rock in rocks)
                {
                    rock.SetActive(false);
                }
            }
            if (GameObject.FindGameObjectWithTag("Power") != null)
            {
                GameObject[] powers = GameObject.FindGameObjectsWithTag("Power");
                foreach (GameObject power in powers)
                {
                    power.SetActive(false);
                }
            }
            if (GameObject.FindGameObjectWithTag("Fly") != null)
            {
                GameObject[] flies = GameObject.FindGameObjectsWithTag("Fly");
                foreach (GameObject fly in flies)
                {
                    fly.SetActive(false);
                }
            }
            if (GameObject.FindGameObjectWithTag("Die") != null)
            {
                GameObject[] dies = GameObject.FindGameObjectsWithTag("Die");
                foreach (GameObject die in dies)
                {
                    die.SetActive(false);
                }
            }
            StartCoroutine(gameOver());
        }
    }

    IEnumerator ReverseScale()
    {
        float timer = 6.0f;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        size = false;
        speed = 5f;
        rigidbody.transform.localScale = new Vector3(2,1,1);
    }

    IEnumerator ReverseFly()
    {
        float timer = 6.0f;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        fly = false;
        speed = 5f;
        rigidbody.transform.rotation = Quaternion.Euler(0,0,0);
        if (gameObject.transform.position.x > 7.87)
        {
            rigidbody.transform.position = new Vector3(7.77f, -3.25f, 1);
        }
        else if (gameObject.transform.position.x < -7.87)
        {
            rigidbody.transform.position = new Vector3(-7.7f, -3.25f, 1);
        }
        else
        {
            rigidbody.transform.position = new Vector3(gameObject.transform.position.x, -3.25f, 1);
        }
    }

    IEnumerator gameOver()
    {
        audio.PlayOneShot(audioDie, 1.0f);
        int finalScore = GameObject.Find("Canvas").GetComponent<Score>().score;
        PlayerPrefs.SetInt("score", finalScore);
        yield return new WaitForSeconds(2);
        GameObject.Find("Canvas").GetComponent<Scenes>().gameOver();
    }
}