using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private UISelectPlantMenu uiSelectPlantMenu;
        [SerializeField] private PlantsCatalog plantsCatalog;
        [SerializeField] private TMP_Text playerExpLabel;
        [SerializeField] private TMP_Text playerCarrotCounterLabel;
        private  List<UISelectIconElement> iconsList;
        private Cell _lastSelectedCell;

        public void SetExpLabel(int value)
        {
            playerExpLabel.text = $"Exp: {value}";
        }
        public void SetCarrotLabel(int value)
        {
            playerCarrotCounterLabel.text = $"Carrot: {value}";
        }
        public void Initialize()
        {
            iconsList = new List<UISelectIconElement>();
            Cell.onCellClicked += OnCellClicked;
            int index = 0;
            foreach (var plantView in plantsCatalog.PlantDataSheet)
            {
                var element = uiSelectPlantMenu.AddIconElement(plantView.GetIcon(), index);
                index++;
                iconsList.Add(element);
                element.onIconSelected += OnIconSelected;
            }
            // uiSelectPlantMenu.Hide();
        }

        public bool IsMenuHide => uiSelectPlantMenu.IsHide;

        public event Action<Cell, PlantView> onPlantSelected;   
        private void OnIconSelected(int index)
        {
            var plant = Instantiate(plantsCatalog.PlantDataSheet[index]);
            plant.gameObject.SetActive(false);
            onPlantSelected?.Invoke(_lastSelectedCell,plant);
            uiSelectPlantMenu.Hide();
        }


        private void OnCellClicked(Cell cell)
        {
            _lastSelectedCell = cell;
            uiSelectPlantMenu.Hide();
            if(!cell.IsEmpty) return;
            uiSelectPlantMenu.transform.position = _lastSelectedCell.transform.position;
            uiSelectPlantMenu.Show();
        }

        private void OnDestroy()
        {
            Cell.onCellClicked -= OnCellClicked;
            foreach (var element in iconsList)
            {
                element.onIconSelected -= OnIconSelected;
            }
        }
        
        

    }
}