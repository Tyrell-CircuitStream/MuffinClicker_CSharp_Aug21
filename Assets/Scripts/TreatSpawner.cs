using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatSpawner : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject[] treatPrefabs;

    public float minSpawnX, maxSpawnX, minSpawnY, maxSpawnY;

    public float minSpawnTime = 3;
    public float maxSpawnTime = 8;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = Random.Range(minSpawnTime, maxSpawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            Spawn();
            currentTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    private void Spawn()
    {
        Vector3 pos = new Vector3(
            Random.Range(minSpawnX, maxSpawnX),
            Random.Range(minSpawnY, maxSpawnY),
            0);

        Transform newTreat = Instantiate(treatPrefabs[Random.Range(0, treatPrefabs.Length)], transform).transform;
        newTreat.localPosition = pos;

        newTreat.GetComponent<Treat>().gameManager = gameManager;
    }
}
