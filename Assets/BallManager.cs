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
        StartCoroutine(StartBallGeneration());
    }

    void Burst()
    {
        Transform ballSpawnPoint = ballSpawnPoints[Random.Range(0, ballSpawnPoints.Count)];
        GameObject spawnedBallPrefab = Instantiate(ballPrefab);
        Ball ball = spawnedBallPrefab.GetComponent<Ball>();

        print(ballSpawnPoint);
        print(player);
        float _;
        if (Random.Range(0f, 1f) >0.5f)
        {
            _ = -1;
        }
        else
        {
            _ = 1f;
        }
        ball.SetData(ballSpawnPoint.position, player.position, new Vector2(0f, _ * Random.Range(50f, 100f)), _ * Random.Range(0.25f, 0.5f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartBallGeneration()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            Burst();
            Burst();
        }
    }
}
