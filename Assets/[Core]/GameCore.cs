using System;
using Plants;
using UI;
using Unity.VisualScripting;
using UnityEngine;

namespace _Core_
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField] private PlantsCatalog _plantsCatalog;
        private Camera _camera;
        [SerializeField] private PlayerView _player;
        [SerializeField] private UIRoot _uiRoot;
        private int _playerExp;
        private int _carrotFruitCount;

        private void Awake()
        {
            _playerExp = 0;
            _camera = Camera.main;
            
            _uiRoot.Initialize();
            _uiRoot.onPlantSelected += OnPlantSelected;
            Carrot.onCarrotFruitHarvest += OnCarrotFruitHarvest;
            PlantView.onPlantRipe += OnPlantRipe;
        }

        private void Start()
        {
            _uiRoot.SetExpLabel(_playerExp);
            _uiRoot.SetCarrotLabel(_carrotFruitCount);
        }

        private void OnPlantRipe(int exp)
        {
            _playerExp += exp;
            _uiRoot.SetExpLabel(_playerExp);
        }

        private void OnCarrotFruitHarvest()
        {
            _uiRoot.SetCarrotLabel(++_carrotFruitCount);
        }

        private void OnPlantSelected(Cell cell, PlantView plant)
        {
            _player.SetDestination(cell);
            _player.TakePlant(plant);
        }

        private void CellClickedHander(Cell cell)
        {
            if (!cell.IsEmpty)
            {
                _player.SetDestination(cell);
            } 
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(!_uiRoot.IsMenuHide) return;
                var target = SelectObject();
                var targetCell = target.GetComponent<Cell>();
                if(targetCell == null) return;
                if(!targetCell.IsEmpty) CellClickedHander(targetCell);  
                targetCell?.OnCellClickedDown(); //todo сделать другой инпут
            }
        }

        private Collider SelectObject()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray,out hitInfo);
            return hitInfo.collider;
        }
    }
}