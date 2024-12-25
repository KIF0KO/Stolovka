using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindowState : State
{
    private GameInput input;
    private Player pl;
    private float period = 0.5f;
    private float nextActionTime = 0;
    private bool _canShoot;
    public override void Enter()
    {
        PizzaHeap.Instance.SwitchPizzaShoot += CanShoot;
        pl = Player.singlton;
        base.Enter();
        Debug.Log("� ������������ � ����");
        Manager.singlton.CamChanger(1);
        Cursor.lockState = CursorLockMode.None;
        nextActionTime = Time.time;

        input = pl.gameInput;
        Enable();
    }
    public override void Exit() 
    {
        PizzaHeap.Instance.SwitchPizzaShoot -= CanShoot;

        base.Exit();
        Manager.singlton.CamChanger(0);
        Cursor.lockState = CursorLockMode.Locked;
        Disable();
    }
    public override void Update()
    {
        base.Update();
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    pl._SM.ChangeState(new MoveState());
        //}
        Shooting();
    }
    private void Shooting()
    {
        if (Time.time > nextActionTime)
        {
            if (!_canShoot)
            {
                return;
            }
            if (Input.GetMouseButton(0))
            {

                Ray ray = Manager.singlton.windowCamera.ScreenPointToRay(Input.mousePosition);
                GameObject obj = Manager.singlton.Spawn(Manager.singlton.pizzaPref);
                obj.GetComponent<Rigidbody>().velocity = ray.direction * 10;

                PizzaHeap.Instance.PizzaEat();

                nextActionTime += period;
            }
            //else if (Input.GetMouseButton(1))
            //{
            //    Ray ray = Manager.singlton.windowCamera.ScreenPointToRay(Input.mousePosition);
            //    GameObject obj = Manager.singlton.Spawn(Manager.singlton.hotDogPref);
            //    obj.GetComponent<Rigidbody>().velocity = ray.direction * 10;

            //    nextActionTime += period;
            //}
            if(Time.time > nextActionTime)
            {
                nextActionTime = Time.time;
            }
        }

        
    }
    
    private void ExitState()
    {
        pl._SM.ChangeState(new MoveState());
    }
    private void OnExitPerfomend(InputAction.CallbackContext obj)
    {
        ExitState();
    }
    private void Enable()
    {
        input.GamePlay.ExitState.performed += OnExitPerfomend;
    }
    private void Disable()
    {
        input.GamePlay.ExitState.performed -= OnExitPerfomend;
    }
    private void CanShoot(bool state)
    {
        _canShoot = state;
    }
}
