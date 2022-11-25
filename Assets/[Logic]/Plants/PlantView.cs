using System;
using System.Collections;
using DG.Tweening;
using Plants;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum PlantStatus
{
    Ripening = 0,
    Ripe = 1
}
public class PlantView : MonoBehaviour
{
    [SerializeField] private PlantData data;
    public PlantStatus Status;

    [SerializeField] private UITimer uiElement;
    [SerializeField] private Sprite iconSprite;
    [SerializeField] private PlantModel model;
    public static event Action<int> onPlantRipe;

    public void Grow()
    {
        StartCoroutine(GrowRoutine());
    }

    public virtual IEnumerator GrowRoutine()
    {
        var RipeningDuration = data.RipeningDuration;
        var Expiriens = data.Expiriens;
        var modelTransform = model.transform;
        modelTransform.localScale = Vector3.zero;
        var timer = 0f;
        while (timer < RipeningDuration)
        {
            var ratio = timer/RipeningDuration;
            modelTransform.localScale = Vector3.one*ratio;
            uiElement.FillAmount(ratio);
            yield return new WaitForSeconds(Time.deltaTime);
            timer += Time.deltaTime;
        }
        print($"Plat is ready");
        Status = PlantStatus.Ripe;
        onPlantRipe?.Invoke(Expiriens);
        uiElement.Hide();
    }
    
    private void OnDrawGizmos()
    {
        Handles.Label(transform.position + Vector3.up*0.5f, $"{Status.ToString()}");
    }

    public Sprite GetIcon() => iconSprite;

    protected void RemovePlant()
    {
        transform.parent.GetComponent<Cell>().IsEmpty = true;
        Destroy(gameObject);
    }
}