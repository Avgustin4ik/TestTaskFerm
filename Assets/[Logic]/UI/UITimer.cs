using UnityEngine;
using UnityEngine.UI;

public class UITimer : UIElement
{
    [SerializeField] private Image backGround;
    public void FillAmount(float value) => backGround.fillAmount = value;

}
