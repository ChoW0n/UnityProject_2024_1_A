using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Loading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExCubePlayer : MonoBehaviour
{
    public Text TextUI = null; // �ؽ�Ʈ UI
    public int Count = 0;      // ���콺 Ŭ�� ī����
    public int Power = 100;// ���� �� ��ġ

    public int Point = 0; // ���� ��ġ
    public float checkTime = 0.0f; // �ð� üũ ǥ��
    public float checkEndTime = 30.0f; // ���� �ð� ���� ����

    public Rigidbody m_Rigidbody;// ������Ʈ�� ��ü

    // Update is called once per frame
    void Update()
    {
        checkEndTime -= Time.deltaTime;

        if(checkEndTime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);
            SceneManager.LoadScene("MainScene");
        }

        checkTime += Time.deltaTime; // �ð��� �����ؼ� �״´� checkTime -> 0��, 1��, 0��, 1��
        if (checkTime >= 1.0f) // 1�ʸ��� � �ൿ�� �Ѵ�.
        {
            Point += 1; // 1�ʸ��� ���� 1���� �ø���.
            checkTime = 0.0f; // �ð��� �ʱ�ȭ�Ѵ�.
        }

        if (Input.GetKeyDown(KeyCode.Space)) // �����̽��� �Է½�
        {
            Power = Random.Range(100, 200); // 100 ~ 200 ������ ������ ���� ���� �ش�
            m_Rigidbody.AddForce(transform.up * Power); // Y������ ������ ���� �ش�.
        }
        TextUI.text = Point.ToString(); // UI ����
        /*if (Input.GetMouseButtonDown(0)) // ���콺 ���� �Է��� �Ǿ��� ��
        {
            Count += 1; // ���콺 �Է��� ������ Count�� 1�� �ø���
            TextUI.text = Count.ToString(); // UI ����
            Power = Random.Range(100, 200); // 100 ~ 200 ������ ������ ���� ���� �ش�
            m_Rigidbody.AddForce(transform.up * Power); // Y������ ������ ���� �ش�.
            
        }

        if (gameObject.transform.position.y >= 2 || gameObject.transform.position.y <= -2)
        { // ������Ʈ�� y���� -2 �����̰ų� 2 �̻��� ��� ���ǹ�
            TextUI.text = "����";
            Count = 0; //���н� ī���� �ʱ�ȭ
        }*/
    }

    private void OnCollisionEnter(Collision collision) // �浹�� �Ǿ�����
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Pipe")
        {
            Point = 0;
            gameObject.transform.position = Vector3.zero; // �÷��̾ �������� �ǵ�����.
        }
        
    }
    private void OnTriggerEnter(Collider other)  //trigger ���� �浹
    {
        if (other.gameObject.tag == "items") // ������ Tag�� Items�� �浹 ���� ��
        {
            Point += 10; // point 10���� �÷��ش�.
            Destroy(other.gameObject); //�ش� ������Ʈ�� �ı� �����ش�.  
        }
    }
}
