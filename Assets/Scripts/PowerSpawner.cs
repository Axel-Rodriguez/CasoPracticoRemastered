using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    public GameObject powers;
    public float posX, posY = 6.0f;

    void Start()
    {
        StartCoroutine(PowerSpawn());
    }

    IEnumerator PowerSpawn()
    {
        while (true)
        {
            posX = Random.Range(-8, 8);

            Instantiate(powers, new Vector3(posX, posY, 0), Quaternion.identity);

            yield return new WaitForSeconds(15);
        }
    }
}
