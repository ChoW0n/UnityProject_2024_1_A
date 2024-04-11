using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExRay : MonoBehaviour
{
    public Text UIText;  //�ؽ�Ʈ ����
    public int Point;  //����Ʈ ����
    public float checkEndTime = 30.0f; // ���� �ð� ���� ����
    void Update()
    {
        checkEndTime -= Time.deltaTime;

        if (checkEndTime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);
            SceneManager.LoadScene("ResultScene");
        }
        if (Input.GetMouseButtonDown(1)) //GetMouseButtonDown(1) ������ ��ư ���콺�� ������ ��
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition); //Ray�� �����ϰ� ī�޶��� ���콺 ��ġ���� Ray�� ���.

            RaycastHit hit;             //Ray�� ��� �浹�� ��ü�� ���� Hit �ֱ� ���� ����

            if(Physics.Raycast(cast, out hit))  //�浹�Ŀ� ���� hit ���� ���
            {
                Debug.Log(hit.collider.gameObject.name);  //�浹�� ������Ʈ�� �̸��� �޾ƿ´�.
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f); //Ray�� �浹�ϸ� ��θ� ������ �����ش�.
                
                if (hit.collider.gameObject.tag == "Target") //�浹�� ������Ʈ�� TAG �̸��� Target �� ���
                {
                    Destroy(hit.collider.gameObject); //�ش� ������Ʈ�� �ı��Ѵ�.
                    Point += 1; //�ı��� ����Ʈ�� ȹ��
                    //if (Point >= 10) DoChangeScene();
                }
            }
            else
            {
                Point = 0; //Miss�� ����Ʈ ����
            }
            UIText.text = Point.ToString();  //UI�� ǥ��
        }
    }
    void DoChangeScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
