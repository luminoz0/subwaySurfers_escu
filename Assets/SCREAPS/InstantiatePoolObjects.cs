using UnityEngine;
using System.Collections.Generic;
public class InstantiatePoolObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private List<GameObject> objectPool = new List<GameObject>();
    private GameObject currentObject;
    public void Initialize() 
    {
        currentObject = null;
        objectPool.Clear();
    }
    public void InstantiateObject(Transform target)
    {
        currentObject = GetPoolObject();
        if (currentObject != null)
        {
            currentObject.transform.position = target.position;
            currentObject.transform.rotation = target.rotation;
            currentObject.SetActive(true);
        }
    }
    public void InstantiateObject(Vector3 position)
    {
        currentObject = GetPoolObject();
        if (currentObject != null)
        {
            currentObject.transform.position = position;
            currentObject.transform.rotation = Quaternion.identity;
            currentObject.SetActive(true);
        }
    }
    private GameObject GetPoolObject()
    {
        foreach (var obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(false);
        objectPool.Add(newObj);
        return newObj;
    }
    public GameObject GetCurrentObject()
    {
        return currentObject;
    }

    public void DeactivateAllObjects()
    {
        foreach (var obj in objectPool)
        {
            obj.SetActive(false);
        }
    }
}
