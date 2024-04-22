using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;
    public float speed = -0.01f;//背景移动速度
    public float shift = 0f;//图片重复点位移量

    public bool isMove = true;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMove) return;
        transform.Translate(speed, 0, 0);
        if(transform.position.x < -5.44f + shift)
        {
            transform.position = startPos;
        }
    }
}
