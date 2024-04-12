using UnityEngine;

public class RiverController : MonoBehaviour
{
    public GameObject boardPrefab; // the board prefab to spawn
    public float spawnRate; // the spawn rate in seconds

    private float timer; // a timer to keep track of the spawn time
    void Start()
    {
        // initialize the timer to zero
        timer = 0f;
    }

    void Update()
    {
        // increment the timer by the time elapsed since the last frame
        timer += Time.deltaTime;

        // check if the timer has reached the spawn rate
        if (timer >= spawnRate)
        {
            // reset the timer
            timer = 0f;

            // create a new board instance at a random position along the river
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0f, transform.position.z);
            Instantiate(boardPrefab, spawnPosition, Quaternion.identity);
        }
    }
    
}