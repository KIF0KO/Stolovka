using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveState : State
{
    RaycastHit hit;
    private float speed = 5;
    public float MousSens = 100f;
    static float xRot = 0;
    private GameInput input;
    Player pl;
    public override void Enter()
    {
        base.Enter();
        Cursor.lockState = CursorLockMode.Locked;
        pl = Player.singlton;
        input = pl.gameInput;
        OnEnable();
        Debug.Log("StartMovement");
    }

    public override void Exit()
    {
        base.Exit();
        Disable();
    }
    public override void Update()
    {
        base.Update();
        Move();
        Look();
    }
    private void Move()
    {
        float horDir = Input.GetAxis("Horizontal");
        float verDir = Input.GetAxis("Vertical");
        pl.rb.velocity = (pl.tr.forward * verDir + pl.tr.right * horDir) * speed;
    }
    private void Look()
    {

        float mousX = Input.GetAxis("Mouse X") * MousSens * Time.deltaTime;
        float mousY = Input.GetAxis("Mouse Y") * MousSens * Time.deltaTime;
        xRot -= mousY;
        //xRot = Mathf.Clamp(xRot, -90f, 90f);

        pl.tr.Rotate(Vector3.up * mousX);
        pl.cam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);



    }
    private void Interactive()
    {
        
            Ray ray = new Ray(pl.cam.transform.position, pl.cam.transform.forward);
            if (Physics.Raycast(ray, out hit, 5))
            {
                if (hit.collider.tag == "Trigger")
                {
                    
                    pl._SM.ChangeState(new WindowState());
                }
                Debug.Log("fu");
            }
        
    }
    private void Scream()
    {
        Ray ray = new Ray(pl.cam.transform.position, pl.cam.transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Worker")
            {
                Debug.Log("WorkerScream");
                hit.collider.transform.GetComponent<WorkerController>().Scream();
            }
        }
    }
    private void OnEnable()
    {
        input.GamePlay.Interactive.performed += OnInteractivePerfomend;
        input.GamePlay.Scream.performed += OnScreamPerfomend;
        Console.WriteLine("ENABLE");
    }
    private void OnInteractivePerfomend(InputAction.CallbackContext obj)
    {
        Interactive();
    }
    private void OnScreamPerfomend(InputAction.CallbackContext obj)
    {
        Scream();
    }
    private void Disable()
    {
        input.GamePlay.Interactive.performed -= OnInteractivePerfomend;
        input.GamePlay.Scream.performed -= OnScreamPerfomend;
    }

}

