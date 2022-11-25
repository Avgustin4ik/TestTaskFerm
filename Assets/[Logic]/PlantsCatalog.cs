using System.Linq;
using UnityEngine;

[CreateAssetMenu(order = 0,fileName = "PlantsCatalog",menuName = "Plants/New PlantsCatalog...")]
public class PlantsCatalog : ScriptableObject
{
    [SerializeField] private PlantView[] plantDataSheet;
    private bool isRawData = true;

    public PlantView[] PlantDataSheet
    {
        get
        {
            if (isRawData)
            {
                isRawData = false;
                return plantDataSheet.Distinct().ToArray();
            }
            return plantDataSheet;
        }
    }
}
