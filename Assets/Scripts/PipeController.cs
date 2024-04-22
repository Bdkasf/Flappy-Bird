using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public Transform Pipes;

    public GameObject PipePrefab; //柱子的预制体

    public Gamemanager gm;

    public float SpawnTime = 2f; //柱子的生成间隔

    private List<GameObject> pipes = new List<GameObject>();

    public bool PipeIsMove = true;

    public void Start()
    {
        StartCoroutine(SpawnPipes());
    }

    /// <summary>
    /// 柱子开始移动
    /// </summary>
    public void StartMove()
    {
        PipeIsMove = true;
        foreach (GameObject item in pipes)
        {
            item.GetComponent<PipeScript>().canMove = true;
        }
    }

    /// <summary>
    /// 柱子停止移动
    /// </summary>
    public void StopMove()
    {
        PipeIsMove = false;
        foreach (GameObject item in pipes)
        {
            item.GetComponent<PipeScript>().canMove = false;
        }
    }

    /// <summary>
    /// 生成柱子
    /// </summary>
    public void SpawnPipe()
    {
        GameObject pipe = GameObject.Instantiate(PipePrefab, Pipes);
        pipe.GetComponent<PipeScript>().RandomHeight();

        pipes.Add(pipe);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            //SpawnPipe();
            StopMove();
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            //SpawnPipe();
            StartMove();
        }
    }

    IEnumerator SpawnPipes()
    {
        while(true)
        {
        yield return new WaitForSeconds(SpawnTime);
        if(!gm.isgameStart) continue;
        if(!PipeIsMove) continue;
        SpawnPipe();
        }
    }
}
