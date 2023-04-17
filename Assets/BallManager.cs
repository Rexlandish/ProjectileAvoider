using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    [SerializeField] GameObject ballPrefab;
    [SerializeField] List<Transform> ballSpawnPoints;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Burst", 0f, 1f);
    }

    void Burst()
    {
        foreach (Transform ballSpawnPoint in ballSpawnPoints)
        {
            GameObject spawnedBallPrefab = Instantiate(ballPrefab);
            Ball ball = spawnedBallPrefab.GetComponent<Ball>();
            print(ballSpawnPoint);
            print(player);
            ball.SetData(ballSpawnPoint, player, Vector2.down * 5f, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
