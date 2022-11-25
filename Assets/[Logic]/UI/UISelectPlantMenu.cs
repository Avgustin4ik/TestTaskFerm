using System;
using UnityEngine;

public class UISelectPlantMenu : UIElement
{
    [SerializeField] private UISelectIconElement elementTemplate;
    [SerializeField]
    private UISelectIconsLayout _layout;
    
    
    private GameObject _layoutGameObject;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
        base.Hide();
    }
    

    public UISelectIconElement AddIconElement(Sprite plantIcon, int index)
    {
        var newElement = Instantiate<UISelectIconElement>(elementTemplate, _layout.transform.position, Quaternion.identity, _layout.transform);
        newElement.SetIcon(plantIcon);
        newElement.SearchIndex = index;
        _layoutGameObject = _layout.gameObject;
        return newElement;
    }
    //todo подкрутить анимацию
    // public override void Show()
    // {
    //     _layoutGameObject.SetActive(true);
    // }
    //
    // public override void Hide()
    // {
    //     _layout.gameObject.SetActive(false);
    // }
}
