using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExResultScene : MonoBehaviour
{
    public Text TextUI; //UI�� ������Ʈ �޾ƿ�

    public void Start()
    {
        TextUI.text = PlayerPrefs.GetInt("Point").ToString(); //����� ���� ǥ��
    }
    public void GoToGame() //��ư�� ȣ���� �Լ� ����
    {
        SceneManager.LoadScene("MainScene"); //Scene �̵�
    }
    
}
