using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExResultScene : MonoBehaviour
{
    public Text TextUI; //UI로 컴포넌트 받아옴

    public void Start()
    {
        TextUI.text = PlayerPrefs.GetInt("Point").ToString(); //저장된 점수 표기
    }
    public void GoToGame() //버튼이 호출할 함수 제작
    {
        SceneManager.LoadScene("MainScene"); //Scene 이동
    }
    
}
