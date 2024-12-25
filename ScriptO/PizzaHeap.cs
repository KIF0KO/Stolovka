using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaHeap : MonoBehaviour
{
    [SerializeField] private Text _text; 
    [SerializeField] private GameObject[] PizzaLayers;
    private int _pizzaInHeap = 0;
    public static PizzaHeap Instance;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _text.text = $"{_pizzaInHeap} / 27";
    }
    void Update()
    {
        if(_pizzaInHeap == 27)
        {
            PizzaPlusLayer(3);
        }
        else if (_pizzaInHeap >= 18)
        {
            PizzaPlusLayer(2);
        }
        else if (_pizzaInHeap >= 9)
        {
            PizzaPlusLayer(1);
        }
        else
        {
            PizzaPlusLayer(0);
        }
    }
    public void PizzaCooked(int quantity = 1) 
    {
        _pizzaInHeap += quantity;
        _text.text = $"{_pizzaInHeap} / 27";
    }
    public void PizzaEat(int quantity = 1)
    {
        _pizzaInHeap -= quantity;
        _text.text = $"{_pizzaInHeap} / 27";
    }
    private void PizzaPlusLayer(int _activeLayerQuality)
    {
        for (int i = 0; i < 3; i++)
        {
            if(i < _activeLayerQuality)
            {
                PizzaLayers[i].gameObject.SetActive(true);
            }
            else
            {
                PizzaLayers[i].gameObject.SetActive(false);
            }
        }
    }
    //private void PizzaMinusLayer()
    //{
    //    if (_pizzaLayers > 0)
    //    {
            
    //        PizzaLayers[_pizzaLayers].SetActive(false);
    //        _pizzaLayers--;
    //    }
    //}
}
