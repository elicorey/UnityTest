using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // 2D array to store the height values for each point on the map
    public float[,] heights;

    // Material to use for the ground
    public Material groundMaterial;

    // Tree prefab to use for populating the map
    public GameObject treePrefab;

    // Maximum number of trees to generate
    public int maxTrees = 1000;

    // Size of the map (in number of points)
    public int mapSize = 256;

    // Maximum height of the map
    public float maxHeight = 20f;

    // Frequency of the noise used to generate the map
    public float noiseFrequency = 0.1f;

    // Persistence of the noise used to generate the map
    public float noisePersistence = 0.5f;

    // Octaves of the noise used to generate the map
    public int noiseOctaves = 6;

    // Seed for the random number generator
    public int seed = 0;

    void Start()
    {
        // Generate the map
        GenerateMap();
    }

    void GenerateMap()
    {
        // Initialize the height array with the specified size
        heights = new float[mapSize, mapSize];

        // Set the seed for the random number generator
        Random.InitState(seed);

        // Generate the noise values for each point on the map
        for (int x = 0; x < mapSize; x++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                // Generate a noise value using Perlin noise
                float noise = Mathf.PerlinNoise(x * noiseFrequency, y * noiseFrequency);
                // Scale and add up the noise values using multiple octaves
                float totalNoise = 0f;
                float amplitude = 1f;
                float frequency = noiseFrequency;
                for (int i = 0; i < noiseOctaves; i++)
                {
                    totalNoise += noise * amplitude;
                    amplitude *= noisePersistence;
                    frequency *= 2f;
                }
                // Scale the noise value to the specified maximum height
                heights[x, y] = totalNoise * maxHeight;
            }
        }

        // Create the ground object and set its material
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.transform.position = new Vector3(mapSize / 2f, 0, mapSize / 2f);
        ground.transform.localScale = new Vector3(mapSize, 1, mapSize);
        ground.GetComponent<Renderer>().material = groundMaterial;

        // Populate the map with trees
        int numTrees = 0;
        for (int x = 0; x < mapSize; x++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                // If we haven't reached the maximum number of trees and if the height is above a certain threshold, instantiate a tree at this point
                if (numTrees < maxTrees && heights[x, y] > 5f)
                {
                    GameObject tree = Instantiate(treePrefab, new Vector3(x, heights[x, y], y), Quaternion.identity);
                    tree.transform.parent = transform;
                    numTrees++;
                }
            }
        }
    }
}

