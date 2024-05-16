using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] circleObject; //��ü �������� �����´�.
    public Transform genTransform;  //���� ��ġ ����
    public float timeCheck;         //���� �ð� ���� ����(float)
    public bool isGen;              //���� üũ (bool)

    public void GenObject()         //���� ���� ������ ���� �����ִ� �Լ�
    {
        isGen = false;              //���� �Ϸ� �Ǿ����� bool �� false ����
        timeCheck = 1.0f;           //���� �Ϸ� �� 1.0�ʷ� �ð� �ʱ�ȭ
    }
    // Start is called before the first frame update
    void Start()
    {
        GenObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGen == false)                                 //isGen �÷��װ� false �� ���
        {
            timeCheck -= Time.deltaTime;                    //�� ������ ���ư��鼭 �ð��� ���� ��Ų��.
            if (timeCheck < 0.0f)                           //0�� ���ϰ� �Ǿ��� ���
            {
                int RandomNumber = Random.Range(0, 3);
                GameObject Temp = Instantiate(circleObject[0]); //������ ���� �� Temp ������Ʈ�� �ִ´�.
                Temp.transform.position = genTransform.position; //���� ��ġ�� ���� ��Ų��.
                isGen = true;
            }
        }
    }


    public void MergeObject(int index, Vector3 position)
    {
        GameObject Temp = Instantiate(circleObject[index]);
        Temp.transform.position = position;
        Temp.GetComponent<CircleObject>().Used();
    }
}
