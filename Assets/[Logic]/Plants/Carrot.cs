using System;

namespace Plants
{
    public class Carrot : PlantView, IInteractable
    {
        public static event Action onCarrotFruitHarvest;
        public void Interact()
        {
            onCarrotFruitHarvest?.Invoke();
            base.RemovePlant();
        }
    }
}