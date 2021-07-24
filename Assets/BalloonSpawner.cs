using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{

    public GameObject balloonPrefab;

    public float spawnPeriod = 3;
    public float spawnTimer;
    // Start is called before the first frame update
    void Awake()
    {
        balloonPrefab = Resources.Load<GameObject>("balloonPrefab");
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer > spawnPeriod) {
            spawnBalloon();
            spawnTimer = 0;
        }
        spawnTimer += Time.deltaTime;

    }

    private void spawnBalloon(){
        GameObject balloon = Instantiate(balloonPrefab);
        balloon.transform.position = transform.position;
    }
}
