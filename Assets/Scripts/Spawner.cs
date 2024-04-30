using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject Coin;

    Coroutine coroutine;

    void Start()
    {
        coroutine = StartCoroutine(Spawn());
    }

    public void StopSpawning()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            switch (Random.Range(1, 3))
            {
                case 1:
                    Destroy(Instantiate(Bomb, new Vector3(Random.Range(minX, maxX), 5), Quaternion.identity), 3);
                    break;
                case 2:
                    Destroy(Instantiate(Coin, new Vector3(Random.Range(minX, maxX), 5), Quaternion.identity), 3);
                    break;
            }
        }
    }
}
