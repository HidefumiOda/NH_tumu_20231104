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
        // ��������{�[���̎�ނ����߂�
        RANDOM_INDEX = Random.Range(0, ballPrefabs.Length);

        // ���������{�[���̎�ނ�ۑ�����
        beforeBall = nowBall;
        nowBall = RANDOM_INDEX;

        // �����O�Ɠ����{�[���𐶐������Ȃ�A���������{�[���̎�ނ�ς���
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

        // ��������{�[����X���W�����߂�
        float RANDOM_X = Random.Range(-2.0f, 2.0f);
        Vector3 BALL_INITIAL_POSITION = new Vector3(RANDOM_X, 7.0f, 0.0f);

        // �{�[���𐶐�����
        GameObject clonedBall = Instantiate(ballPrefabs[RANDOM_INDEX]);

        // ���������{�[���̈ʒu��ݒ肷��
        clonedBall.transform.position = BALL_INITIAL_POSITION;

        // 0.5�b�҂�
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
