using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour
{
    [field: SerializeField] public Transform PlantPoint { get; private set; }
    public PlantStatus GetPlantStatus => _plant.Status;
    private void Awake()
    {
    }


    private void OnDestroy()
    {
    }

    private bool _isEmpty = true;
    public bool IsEmpty
    {
        get => _isEmpty;
        set => _isEmpty = value;
    }

    private bool _isUIHide = true;
    private PlantView _plant;
    public static event Action<Cell> onCellClicked;
    public void OnCellClickedDown()
    {
        var position = transform.position + Vector3.up*2f;
        onCellClicked?.Invoke(this);
    }

    public void TakePlant(PlantView plantView)
    {
        _isEmpty = false;
        plantView.transform.SetParent(transform);
        plantView.gameObject.SetActive(true);
        _plant = plantView;
        _plant.Grow();
    }
    [ContextMenu("Interact")]
    public void InteractWithPlant()
    {
        var interactablePlant = _plant as IInteractable;
        if (interactablePlant == null) return;
        interactablePlant.Interact();
    }
}
