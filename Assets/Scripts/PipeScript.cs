using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float pipespeed = 0.05f; //柱子的移动速度

    public bool canMove = true;

    public void FixedUpdate() 
    {
        if(!canMove) return;
        transform.Translate(-pipespeed, 0, 0);
    }

/// <summary>
/// 柱子的生成高度
/// </summary>
    public void RandomHeight()
    {
        //up3.2 down 1.3
        float r = Random.Range(-1.3f, 3.2f);
        transform.SetPositionAndRotation(new Vector3(transform.position.x, r, transform.position.z), transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<Gamemanager>().GameOver();
        GameObject.Find("BackGrounds").GetComponent<bgController>().isMove = false;
        GameObject.Find("Grounds").GetComponent<bgController>().isMove = false;
    }
}
