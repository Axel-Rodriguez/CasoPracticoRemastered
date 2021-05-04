using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rocks;
    public float posX, posY = 6.0f;

    void Start()
    {
        StartCoroutine(RockSpawn());
    }

    IEnumerator RockSpawn()
    {
        while (true)
        {
            posX = Random.Range(-8, 8);

            Instantiate(rocks, new Vector3(posX, posY, 0), Quaternion.identity);

            yield return new WaitForSeconds(1);
        }
    }
}