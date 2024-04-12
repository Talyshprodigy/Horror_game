using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject carPrefab;
    private bool canSpawn;
    void Start()
    {
        StartCoroutine(SpawnEnumerator());
    }
    private IEnumerator SpawnEnumerator()
    {
        yield return new WaitForSeconds(2.5f);
        Instantiate(carPrefab, transform.position, transform.rotation);
        StartCoroutine(SpawnEnumerator());
    }
}
