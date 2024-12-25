using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Animations;
using UnityEngine;

public class WorkerController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float _timerPizza = 0;
    private float _periodPizza = 3;
    private float period = 20;
    private float timer = 0;
    private bool worked = false;
    private void Update()
    {
        if (worked)
        {
            if (Time.time >= _timerPizza)
            {
                PizzaHeap.Instance.PizzaCooked();
                _timerPizza = Time.time + _periodPizza;
                Debug.Log("Cooked");
            }
            if (Time.time >= timer)
            {
                animator.SetBool("WorkerState", false);
                worked = false;
                timer = Time.time + period;
            }
            
        }
        
    }
    public void Scream()
    {
        Debug.Log("Scream");
        worked = true;
        animator.SetBool("WorkerState", true);
    }
}
