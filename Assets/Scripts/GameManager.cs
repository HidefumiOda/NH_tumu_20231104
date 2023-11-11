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
        // 50��J��Ԃ�
        for (int i = 1; i <= 50; i++)
        {
            // ��������{�[���̎�ނ����߂�
            RANDOM_INDEX = Random.Range(0, ballPrefabs.Length);

            // ���������{�[���̎�ނ�ۑ����� (1)
            beforeBall = nowBall;

            // �����O�Ɠ����{�[���𐶐������Ȃ�
            if (RANDOM_INDEX == beforeBall)
            {
                // ���������{�[���̎�ނ�ς���
                if (RANDOM_INDEX == 0)
                {
                    RANDOM_INDEX = RANDOM_INDEX + 1;
                }
                else
                {
                    RANDOM_INDEX = RANDOM_INDEX - 1;
                }
            }

            // ���������{�[���̎�ނ�ۑ����� (2)
            nowBall = RANDOM_INDEX;

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
    }
    public GameObject[] ballPrefabs;
    void Start()
    {
        StartCoroutine("DropBall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
