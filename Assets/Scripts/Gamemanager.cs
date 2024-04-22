using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class Gamemanager : MonoBehaviour
{
    public GameObject main;
    public GameObject tutorial;
    public GameObject score;
    public GameObject bird;
    public GameObject NewScore;
    public GameObject over;

    public Text nowScoreText;
    public Text bestScoreText;
    public Text scoreText;

    public Image Medal;
    public List<Sprite> medals;

    public bool isgameReady;
    public bool isgameStart;

    public bool isgameStarted;

    // public void Start()
    // {
    //     PlayerPrefs.SetInt("bestScore", 0);//分数清零
    // }
    public void PlayBtnClick()
    {
        if(!isgameStarted)
        {
        Tools.Ins.HideUI(main);
        Tools.Ins.ShowUI(tutorial);
        Tools.Ins.ShowUI(score);
        bird.GetComponent<BirdController>().ChangeState(true);
        isgameReady = true;
        isgameStarted = true;
        }
    }

    private void Update()
    {
        if(!isgameReady) return;
        if(isgameStart) return;
        if(Input.GetMouseButtonDown(0))
        {
            Tools.Ins.HideUI(tutorial);
            bird.GetComponent<BirdController>().Fly();
            bird.GetComponent<BirdController>().ChangeState(true, true);
            isgameStart = true;
        }
    }

/// <summary>
/// 游戏结束
/// </summary>
    public void GameOver()
    {
        if(!isgameStart) return;

        isgameReady = false;
        isgameStart = false;

        GameObject.Find("PipeController").GetComponent<PipeController>().StopMove();
        GameObject.Find("BackGrounds").GetComponent<bgController>().isMove = false;
        GameObject.Find("Grounds").GetComponent<bgController>().isMove = false;

        Tools.Ins.ShowUI(over);
        //拿到分数
        int score = int.Parse(scoreText.text);

        if(score >= 50)
        {
            Medal.sprite = medals[3];
        }
        else if(score >= 30)
        {
            Medal.sprite = medals[2];
        }
        else if (score >= 10)
        {
            Medal.sprite = medals[1];
        }
        else if (score >= 5)
        {
            Medal.sprite= medals[0];
        }
        else
        {
            Medal.gameObject.SetActive(false);
        }

        if(PlayerPrefs.GetInt("bestScore") < score)
        {
            PlayerPrefs.SetInt("bestScore", score);
            NewScore.SetActive(true);
        }

        nowScoreText.text = score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();
    }

/// <summary>
/// 得分
/// </summary>
    public void GetScore()
    {
        if(!isgameStart) return;
        scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
    }

/// <summary>
/// 重新开始
/// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
