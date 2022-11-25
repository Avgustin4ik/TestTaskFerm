
using UnityEngine;

namespace Plants
{
    [CreateAssetMenu(order = 0,fileName = "PlantData",menuName = "Data/New Plant..")]
    public class PlantData : ScriptableObject
    {
        [field: SerializeField] public float RipeningDuration { get; private set; }
        [field: SerializeField, Min(0)] public int Expiriens { get; private set; }
    }
}