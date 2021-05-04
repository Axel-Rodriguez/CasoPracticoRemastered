using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject rocks, powers, flies, dies;
    private float posX, posY = 6.0f, randomVal;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            posX = Random.Range(-8, 8);
            randomVal = Random.value;

            if(randomVal < 0.13f)
            {
                Instantiate(powers, new Vector3(posX, posY, 0), Quaternion.identity);
            }
            else if (randomVal > 0.12f && randomVal < 0.22f)
            {
                Instantiate(flies, new Vector3(posX, posY, 0), Quaternion.identity);
            }
            else if (randomVal > 0.21f && randomVal < 0.66f)
            {
                Instantiate(dies, new Vector3(posX, posY, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(rocks, new Vector3(posX, posY, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.33f);
        }
    }
}
