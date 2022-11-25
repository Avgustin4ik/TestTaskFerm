using System;
using Plants;
using TMPro;
using UnityEngine;

public class CarrotScoreLabel : MonoBehaviour
{
    private int _carrotCount = 0;
    [SerializeField] private TMP_Text _tmpText;

    private void Awake()
    {
        SetLabel(_carrotCount);
        Carrot.onCarrotFruitHarvest += OnCarrotFruitHarvest;
    }

    private void SetLabel(int carrotCount)
    {
        _tmpText.text = $"Carrots: {carrotCount}";
    }


    private void OnDestroy()
    {
        Carrot.onCarrotFruitHarvest -= OnCarrotFruitHarvest;
    }

    private void OnCarrotFruitHarvest()
    {
        SetLabel(++_carrotCount);
    }
}
