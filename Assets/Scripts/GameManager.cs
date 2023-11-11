using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int nowBall;
    int beforeBall;
    int RANDOM_INDEX;
    private IEnumerator DropBall()
    {
        // 生成するボールの種類を決める
        RANDOM_INDEX = Random.Range(0, ballPrefabs.Length);

        // 生成したボールの種類を保存する
        beforeBall = nowBall;
        nowBall = RANDOM_INDEX;

        // もし前と同じボールを生成されるなら、生成されるボールの種類を変える
        if (nowBall == beforeBall)
        {
            if(RANDOM_INDEX == 4)
            {
                RANDOM_INDEX = RANDOM_INDEX - 1;
            }
            else
            {
                RANDOM_INDEX = RANDOM_INDEX + 1;
            }
        }

        // 生成するボールのX座標を決める
        float RANDOM_X = Random.Range(-2.0f, 2.0f);
        Vector3 BALL_INITIAL_POSITION = new Vector3(RANDOM_X, 7.0f, 0.0f);

        // ボールを生成する
        GameObject clonedBall = Instantiate(ballPrefabs[RANDOM_INDEX]);

        // 生成したボールの位置を設定する
        clonedBall.transform.position = BALL_INITIAL_POSITION;

        // 0.5秒待つ
        yield return new WaitForSeconds(0.5f);
    }
    public GameObject[] ballPrefabs;
    void Start()
    {
        for(int i = 1; i <= 50; i++)
        {
            StartCoroutine("DropBall");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
