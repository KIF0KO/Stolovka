using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player singlton { get; private set;}

    public StateMachine _SM;

    public Rigidbody rb;
    public Transform tr;
    public Camera cam;

    public GameInput gameInput;
    private void Awake()
    {
        singlton = this;
        gameInput = new GameInput();
        gameInput.Enable();
    }
    void Start()
    {
        
        _SM = new StateMachine();
        _SM.Initialize(new MoveState());

        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        _SM.CurrentState.Update();

    }
}
