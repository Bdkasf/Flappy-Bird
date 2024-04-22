using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using DG.Tweening;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    new public Rigidbody2D rigidbody2D;
    public Animator animator;
    public Gamemanager gamemanager;
    public float mul = 1f; //鸟的转向倍率
    public Transform birdImg;
    public float birdSpeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        //animator.SetInteger("state", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(!gamemanager.isgameStart) 
        {
        return;
        }
        else if (!rigidbody2D.simulated)
        {
            rigidbody2D.simulated = true;
        }

        if(Input.GetMouseButtonDown(0))
        {
            Fly();
        }

        birdImg.transform.DORotateQuaternion(Quaternion.Euler(0, 0, rigidbody2D.velocity.y * mul), 0.3f);
    }

    public void Fly()
    {
        rigidbody2D.velocity = new Vector2(0, birdSpeed);
    }

    public void ChangeState(bool isFly, bool isSim = false)
    {
        if(isFly)
        {
            animator.SetInteger("state", 0);
            rigidbody2D.simulated = isSim;
        }
        else
        {
            animator.SetInteger("state", 1);
            rigidbody2D.simulated = isSim;
        }
    }
}
