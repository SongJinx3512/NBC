using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // event 외부에서는 호출하지 못하게 막는다
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;

    protected bool IsAttacking { get; set; }


    protected virtual void Update()
    {
        HandleAttackDelay();
    }


    private void HandleAttackDelay()
    {
        if (_timeSinceLastAttack <= 0.2f) // TODO
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastAttack > 0.2f)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }    


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }


    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction); 
    } 

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}







//// 이동 연습 코드
//{
//    //private float speed = 5f;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //float x = Input.GetAxisRaw("Horizontal");
//        //float y = Input.GetAxisRaw("Vertical");

//        //transform.position += new Vector3(x, y) * speed * Time.deltaTime;
//    }
//}
