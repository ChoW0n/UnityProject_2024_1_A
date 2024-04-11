using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExRay : MonoBehaviour
{
    public Text UIText;  //텍스트 정의
    public int Point;  //포인트 정의
    public float checkEndTime = 30.0f; // 게임 시간 종료 설정
    void Update()
    {
        checkEndTime -= Time.deltaTime;

        if (checkEndTime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);
            SceneManager.LoadScene("ResultScene");
        }
        if (Input.GetMouseButtonDown(1)) //GetMouseButtonDown(1) 오른쪽 버튼 마우스가 눌렸을 때
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition); //Ray를 정의하고 카메라의 마우스 위치에서 Ray를 쏜다.

            RaycastHit hit;             //Ray를 쏘고 충돌할 물체의 값을 Hit 넣기 위한 정의

            if(Physics.Raycast(cast, out hit))  //충돌후에 값이 hit 있을 경우
            {
                Debug.Log(hit.collider.gameObject.name);  //충돌한 오브젝트의 이름을 받아온다.
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f); //Ray가 충돌하면 경로를 선으로 보여준다.
                
                if (hit.collider.gameObject.tag == "Target") //충돌한 오브젝트의 TAG 이름이 Target 일 경우
                {
                    Destroy(hit.collider.gameObject); //해당 오브젝트를 파괴한다.
                    Point += 1; //파괴시 포인트를 획득
                    //if (Point >= 10) DoChangeScene();
                }
            }
            else
            {
                Point = 0; //Miss시 포인트 리셋
            }
            UIText.text = Point.ToString();  //UI에 표시
        }
    }
    void DoChangeScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
