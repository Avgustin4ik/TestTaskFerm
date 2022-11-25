using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISelectIconElement : MonoBehaviour, IPointerDownHandler
{
    public event Action<int> onIconSelected; 
    //todo привести к единообразию
    [SerializeField] private Image _image ;
    private int _searchIndex;

    public int SearchIndex
    {
        get => _searchIndex;
        set => _searchIndex = value;
    }

    public void SetIcon(Sprite icon) => _image.sprite = icon;
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        onIconSelected?.Invoke(SearchIndex);
    }
}

