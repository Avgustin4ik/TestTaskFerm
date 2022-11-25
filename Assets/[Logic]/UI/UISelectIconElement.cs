using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISelectIconElement : MonoBehaviour, IPointerDownHandler
{
    //todo привести к единообразию
    [SerializeField] private Image _image ;
    private int _searchIndex;

    public int SearchIndex
    {
        get => _searchIndex;
        set => _searchIndex = value;
    }

    private void Awake()
    {
    }

    public void SetIcon(Sprite icon) => _image.sprite = icon;
    
    public event Action<int> onIconSelected; 
    
    public void OnPointerDown(PointerEventData eventData)
    {
        onIconSelected?.Invoke(SearchIndex);
    }
}

