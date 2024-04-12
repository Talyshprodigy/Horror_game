using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject[] terrainPrefabs; // Prefabs for road, sidewalk, and grass
    public Transform generationPoint;   // Point where terrain is generated
    public float distanceBetween;
    public float repeatRate;// Distance between each terrain piece

    private int terrainIndex;           // Index to select terrain type

    void Start()
    {
        //InvokeRepeating("GenerateTerrain", 0f, repeatRate);
        for (int i = 0; i < 20; i++)
        {
            GenerateTerrain();
        }
    }

    void GenerateTerrain()
    {
        // Randomly select terrain index (0 = road, 1 = sidewalk, 2 = grass)
        terrainIndex = Random.Range(0, terrainPrefabs.Length);

        // Instantiate selected terrain prefab at generation point
        GameObject newTerrain = Instantiate(terrainPrefabs[terrainIndex], generationPoint.position, generationPoint.rotation);

        // Move generation point forward by distanceBetween units
        generationPoint.position += new Vector3(0, 0f, distanceBetween);
    }
}