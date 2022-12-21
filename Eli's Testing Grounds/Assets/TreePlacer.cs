using UnityEngine;

public class TreePlacer : MonoBehaviour
{
    // Public variables
    public GameObject treePrefab; // The tree prefab to instantiate
    public int treeCount = 10; // The number of trees to instantiate
    public Vector2 placementArea = new Vector2(100, 100); // The area in which to place the trees (in meters)
    public GameObject ground; // The ground object on which to place the trees

    // Private variables
    private float xMin, xMax, zMin, zMax; // The minimum and maximum values for x and z coordinates

    void Start()
    {
        // Calculate the minimum and maximum values for the x and z coordinates
        xMin = ground.transform.position.x - placementArea.x / 2;
        xMax = ground.transform.position.x + placementArea.x / 2;
        zMin = ground.transform.position.z - placementArea.y / 2;
        zMax = ground.transform.position.z + placementArea.y / 2;

        // Instantiate the specified number of trees
        for (int i = 0; i < treeCount; i++)
        {
            // Generate random x and z coordinates within the placement area
            float x = Random.Range(xMin, xMax);
            float z = Random.Range(zMin, zMax);

            // Calculate the y coordinate by raycasting down from the top of the tree
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(x, 100, z), Vector3.down, out hit))
            {
                // Check if the raycast hits the ground object
                if (hit.collider.gameObject == ground)
                {
                    float y = hit.point.y;

                    // Instantiate the tree at the calculated position
                    GameObject tree = Instantiate(treePrefab, new Vector3(x, y, z), Quaternion.identity);

                    // Make the tree permanent
                    DontDestroyOnLoad(tree);
                }
            }
        }

        // Make the GameObject that the script is attached to permanent
        DontDestroyOnLoad(this.gameObject);
    }
}


