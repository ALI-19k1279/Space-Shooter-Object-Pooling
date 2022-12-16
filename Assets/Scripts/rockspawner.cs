using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockspawner : MonoBehaviour
{
    [SerializeField]
    private GameObject rockPrefab;
    void Start()
    {
        InvokeRepeating("launch", 2.0f, 2.0f);
        // Vector3 rockPosition = new Vector3(8, Random.Range(-2,2), -1);
        // Instantiate(rockPrefab, rockPosition, Quaternion.identity);
    }
    void launch()
    {
        Vector3 rockPosition = new Vector3(8, Random.Range(-2,2), -1);
        Instantiate(rockPrefab, rockPosition, Quaternion.identity);
    }
}
