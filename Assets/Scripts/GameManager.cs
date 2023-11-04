using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    void Start()
    {
        for(int i = 1; i <= 50; i++)
        {
            int RANDOM_INDEX = Random.Range(0, ballPrefabs.Length);
            GameObject clonedBall = Instantiate(ballPrefabs[RANDOM_INDEX]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
