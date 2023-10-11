using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dongle : MonoBehaviour
{
    public int level;
    public bool isDrag;
    Rigidbody2D rigid;
    Animator anim;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void OnEnable()
    {
        anim.SetInteger("Level", level);
    }


    // Update is called once per frame
    void Update()
    {
        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float leftBorder = -4.2f + transform.localScale.x / 2f;
            float rightBorder = 4.2f - transform.localScale.y / 2f;

            if (mousePos.x < leftBorder)
            {
                mousePos.x = leftBorder;
            }

            else if (mousePos.x > rightBorder)
            {
                mousePos.x = rightBorder;
            }

            mousePos.y = 8;
            mousePos.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);
        }
    }


    public void Drag()
    {
        isDrag = true;
    }


    public void Drop()
    {
        isDrag = false;
        rigid.simulated = true;
    }
}
