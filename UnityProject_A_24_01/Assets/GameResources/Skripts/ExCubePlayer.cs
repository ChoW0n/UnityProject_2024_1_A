using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Loading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExCubePlayer : MonoBehaviour
{
    public Text TextUI = null; // 텍스트 UI
    public int Count = 0;      // 마우스 클릭 카운터
    public int Power = 100;// 물리 힘 수치

    public int Point = 0; // 점수 수치
    public float checkTime = 0.0f; // 시간 체크 표시
    public float checkEndTime = 30.0f; // 게임 시간 종료 설정

    public Rigidbody m_Rigidbody;// 오브젝트의 강체

    // Update is called once per frame
    void Update()
    {
        checkEndTime -= Time.deltaTime;

        if(checkEndTime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);
            SceneManager.LoadScene("MainScene");
        }

        checkTime += Time.deltaTime; // 시간을 누적해서 쌓는다 checkTime -> 0초, 1초, 0초, 1초
        if (checkTime >= 1.0f) // 1초마다 어떤 행동을 한다.
        {
            Point += 1; // 1초마다 점수 1점을 올린다.
            checkTime = 0.0f; // 시간을 초기화한다.
        }

        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바 입력시
        {
            Power = Random.Range(100, 200); // 100 ~ 200 사이의 랜덤한 값의 힘을 준다
            m_Rigidbody.AddForce(transform.up * Power); // Y축으로 설정한 힘을 준다.
        }
        TextUI.text = Point.ToString(); // UI 갱신
        /*if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 입력이 되었을 때
        {
            Count += 1; // 마우스 입력이 들어오면 Count를 1씩 올린다
            TextUI.text = Count.ToString(); // UI 갱신
            Power = Random.Range(100, 200); // 100 ~ 200 사이의 랜덤한 값의 힘을 준다
            m_Rigidbody.AddForce(transform.up * Power); // Y축으로 설정한 힘을 준다.
            
        }

        if (gameObject.transform.position.y >= 2 || gameObject.transform.position.y <= -2)
        { // 오브젝트의 y값이 -2 이하이거나 2 이상일 경우 조건문
            TextUI.text = "실패";
            Count = 0; //실패시 카운터 초기화
        }*/
    }

    private void OnCollisionEnter(Collision collision) // 충돌이 되었을때
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Pipe")
        {
            Point = 0;
            gameObject.transform.position = Vector3.zero; // 플레이어를 원점으로 되돌린다.
        }
        
    }
    private void OnTriggerEnter(Collider other)  //trigger 통한 충돌
    {
        if (other.gameObject.tag == "items") // 설정한 Tag로 Items와 충돌 했을 때
        {
            Point += 10; // point 10점을 올려준다.
            Destroy(other.gameObject); //해당 오브젝트를 파괴 시켜준다.  
        }
    }
}
