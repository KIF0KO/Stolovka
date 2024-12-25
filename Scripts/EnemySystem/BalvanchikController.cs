using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalvanchikController : MonoBehaviour
{
    public Vector3 _whereMove;
    [SerializeField] private float _period;
    private float _timer;
    void Start()
    {
        _timer = Time.time + 16;
    }
    private void Update()
    {
        if (Time.time > _timer)
        {
            Angry.AngryPlus(0.16f);
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if(_whereMove != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, _whereMove, 0.5f);
        }
    }
    private void OnDestroy()
    {
        //EnemyControllerInWindow.EnemyNearWindow.Remove(transform.gameObject);
    }

}
