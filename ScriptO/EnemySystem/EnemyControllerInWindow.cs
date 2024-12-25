using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyControllerInWindow : MonoBehaviour
{
    [SerializeField] private Transform[] posEnemy;
    private Vector3[] _posEnemy;
    [SerializeField] private GameObject BalvancaObj;
    public static GameObject[] EnemyNearWindow;
    public static float periodSpawn = 2f;
    private float timer = 0;
    //private bool[] _posFill = new bool[6];
    private int colvoFreedomBalvanok = 0;
    
    void Start()
    {
        WriteInMass();
        EnemyNearWindow = new GameObject[6];
        timer = Time.time;
    }
    void Update()
    {
        if (Time.time >= timer)
        {
            //EnemyNearWindow.Add(Instantiate(BalvancaObj, transform.position, Quaternion.LookRotation(new Vector3(0, 90, 0))));
            colvoFreedomBalvanok++;

            if (EnemyNearWindow.Length > 6)
            {
                EnemyNearWindow[EnemyNearWindow.Length - 1].SetActive(false);
            }
            timer = Time.time;
            timer += periodSpawn;
        }
        for (int i = 0; i < 6; i++)
        {
            try
            {
                var a = EnemyNearWindow[i].transform;
            }
            catch
            {
                if (colvoFreedomBalvanok > 0) {
                    EnemyNearWindow[i] = Instantiate(BalvancaObj, transform.position, Quaternion.LookRotation(new Vector3(0, 90, 0)));
                    colvoFreedomBalvanok--;
                }
            }
            Fridrih(i, i);
        }
    }
    private void Fridrih(int numPlace, int numInList)
    {
        EnemyNearWindow[numInList].transform.GetComponent<BalvanchikController>()._whereMove = _posEnemy[numPlace ];
    }
    //private bool RandomPlace(int i, int colvoIter)
    //{
        
    //    colvoIter++;
    //    if (colvoIter >= 6)
    //    {
    //        for (int f = 0; f < 6; f++)
    //        {
    //            if (_posFill[f] == false)
    //            {
    //                Fridrih(f, i);
    //                return true;
    //            }
    //        }
    //    }
    //    int num = Random.Range(0, 6);
    //    if (_posFill[num] == false)
    //    {
    //        Fridrih(num, i);
    //        _posFill[num] = true;
    //        return true;
    //    }
    //    else
    //    {
    //        Debug.Log("ITupik");
    //        if(!RandomPlace(i, colvoIter))
    //        {
    //            return false;
    //        }
    //    }
        
    //    return false;
    //}
    private void WriteInMass()
    {
        _posEnemy = new Vector3[posEnemy.Length];
        for(int i = 0; i < posEnemy.Length; i++)
        {
            _posEnemy[i] = posEnemy[i].position;
        }
    }
}
