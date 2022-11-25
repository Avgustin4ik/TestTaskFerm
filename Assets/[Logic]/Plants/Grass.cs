namespace Plants
{
    public class Grass : PlantView, IInteractable
    {
        public void Interact()
        {
            RemovePlant();
        }
    }
}