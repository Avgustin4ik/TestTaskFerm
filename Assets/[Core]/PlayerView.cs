using System;
using UnityEngine;
using UnityEngine.AI;

    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent ;
        [SerializeField] private Animator animator;
        private PlantView _plant;
        private Cell _targetCell;


        public void SetDestination(Cell target)
        {
            _targetCell = target;
            print($"Destination send target hash = {target.gameObject.GetHashCode()}");
            agent.SetDestination(target.transform.position);
        }

        public void TakePlant(PlantView plant)
        {
            _plant = plant;
            _plant.transform.position = transform.position;
            _plant.transform.SetParent(transform);
        }
        
        private void LateUpdate()
        {
            var velocitySqrMagnitude = agent.velocity.sqrMagnitude;
            if (velocitySqrMagnitude > 0.1f)
            {
                animator.SetBool("IsMoving",true);
                animator.SetFloat("Speed", velocitySqrMagnitude/2f);
            }
            if (agent.hasPath)
            {
                if(_targetCell == null) return;
                if (agent.pathStatus == NavMeshPathStatus.PathComplete)
                {
                    double minDistance = 0.2f;
                    if((transform.position - _targetCell.transform.position).sqrMagnitude > agent.stoppingDistance) return;
                    print($"Path complete");
                    Interract();
                }
            }
        }

        private void Interract()
        {
            if (_targetCell.IsEmpty)
            {
                _targetCell.TakePlant(_plant);
                _plant = null;
                _targetCell = null;
                return;
            }

            if (!_targetCell.IsEmpty)
            {
                if(_targetCell.GetPlantStatus == PlantStatus.Ripening) return;
                _targetCell.InteractWithPlant();
                _targetCell = null;
            }
        }
    }
