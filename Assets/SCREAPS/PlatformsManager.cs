using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    [SerializeField]
    private Transform platformsPivot;
    [SerializeField]
    private InstantiatePoolObjects[] platformPrefabs;
    [SerializeField]
    private int initialPlatforms = 5;
    [SerializeField]
    private float speed = 5f;
    private bool isRunning = true;
    private GameObject lastPlatform;
    public void StartGame()
    {
        transform.position = platformsPivot.position;
        lastPlatform = null;
        InitializePlatforms();
        InstantiatePlatform(initialPlatforms);
        isRunning = true;
    }
    private void InitializePlatforms()
    {
        foreach (var platform in platformPrefabs)
        {
                platform.DeactivateAllObjects();
        }
    }
    public void InstantiatePlatform(int number)
    {
        for (int i = 0; i < number; i++)
        {
            InstantiatePoolObjects instantiatePool = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            Vector3 spawnPosition = Vector3.zero;
            if (lastPlatform != null)
            {
                spawnPosition = lastPlatform.transform.position + lastPlatform.GetComponent<Collider>().bounds.size.z * Vector3.forward * 0.5f;
            }
            instantiatePool.InstantiateObject(spawnPosition);
            GameObject newPlatform = instantiatePool.GetCurrentObject();
            newPlatform.transform.SetParent(transform);
            Collider newCol = newPlatform.GetComponent<Collider>();
            newPlatform.transform.position = spawnPosition + newCol.bounds.size.z * Vector3.forward * 0.5f;
            lastPlatform = newPlatform;
        }
    }
    private void Update()
    {
        if (isRunning)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
    public void StopPlatforms()
    {
        isRunning = false;
    }
}