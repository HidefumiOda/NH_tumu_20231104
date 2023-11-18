using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject GetCurrentTarget()
    {
        GameObject atDeleteTarget = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

        if (hit2d)
        {
            atDeleteTarget = hit2d.transform.gameObject;
        }
        return atDeleteTarget;
    }

    private List<GameObject> removableBallList = new List<GameObject>();
    private CommonBall firstBall = null;
    private void OnDragStart()
    {
        GameObject targetObject = GetCurrentTarget();
        removableBallList.Clear();
        if (targetObject)
        {
            if(targetObject.name.IndexOf("Ball") != -1)
            {
                firstBall = targetObject.GetComponent<CommonBall>();
                removableBallList.Add(targetObject);
                firstBall.isAdd = true;
            }
        }
    }

    private void OnDragging()
    {
        GameObject targetObject = GetCurrentTarget();
        if (targetObject)
        {
            if(targetObject.name.IndexOf("Ball") != -1)
            {
                CommonBall targetBall = targetObject.transform.GetComponent<CommonBall>();
                if(targetBall.kind0fld == firstBall.kind0fld)
                {
                    if(targetBall.isAdd == false)
                    {
                        removableBallList.Add(targetObject);
                        targetBall.isAdd = true;
                    }
                }
            }
        }
    }

    private void OnDragEnd()
    {
        firstBall = null;
        int length = removableBallList.Count;
        if (length >= 3)
        {
            foreach (GameObject ball in removableBallList)
            {
                Destroy(ball);
            }
        }
        else
        {
            foreach (GameObject ball in removableBallList)
            {
                ball.GetComponent<CommonBall>().isAdd = false;
            }
        }
    }

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
    private bool isDragged = false;
    void Start()
    {
        StartCoroutine(DropBall());
    }
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && isDragged == false)
        {
            isDragged = true;
            OnDragStart();
        }
        else if(Input.GetMouseButton(0) && isDragged == true)
        {
            OnDragging();
        }
        else
        {
            isDragged = false;
            OnDragEnd();
        }
    }
}
