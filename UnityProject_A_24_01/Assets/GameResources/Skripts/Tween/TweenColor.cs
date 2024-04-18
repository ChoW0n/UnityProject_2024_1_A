using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenColor : MonoBehaviour
{
    private Renderer renderer;      //랜더러를 선언한다.
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();   //컴포넌트를 가져온다.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     //스페이스를 눌럿을 때
        {
            Color color = new Color(Random.value, Random.value, Random.value);  //랜덤 색을 가져온다

            renderer.material.DOColor(color, 1f)
                .SetEase(Ease.InOutQuad);

            renderer.material.DOPlay();
        }
        
    }
}
