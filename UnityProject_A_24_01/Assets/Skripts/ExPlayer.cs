using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExPlayer : MonoBehaviour
{
    public int Hp = 100;
    public Text TextUI = null; // 유니티 UI에 접근하기 위해 사용

    // Update is called once per frame
    void Update()
    {
        TextUI.text = Hp.ToString(); // UI 체력 표시
        if(Input.GetMouseButtonDown(0)) // 마우스 왼쪽 입력이 되었을 때
        {
            Hp -= 10; // Hp -10
            if(Hp <= 0) // Hp가 0 이하일 시 파괴
            {
                Destroy(gameObject); // gameObject는 이 스크립트가 붙은 오브젝트가 해당됨
            }
        }
    }
}
