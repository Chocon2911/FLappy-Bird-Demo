using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : HaoMonoBehaviour
{
    public float jumpHeight;

    [SerializeField] protected static InputManager instance;
    public static InputManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected virtual void Update()
    {
        this.InputJump();
    }

    protected virtual void InputJump()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            this.jumpHeight = 3.5f;
            Debug.Log("InputJump");
        }
        else
        {
            this.jumpHeight -= 10f * Time.deltaTime;
            Debug.Log("Not Jump");
        }
    }
}
