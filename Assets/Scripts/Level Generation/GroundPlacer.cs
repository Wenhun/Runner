using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.LevelGeneration
{
    public class GroundPlacer : MonoBehaviour
    {
        [Header("Grounds Prefabs")]
        [SerializeField] private GroundGenerator _groundPrefab;
        [SerializeField] private GroundGenerator _firstGround;

        [Header("Creation Settings")]
        [SerializeField, Range(1, 4)] int countStartGrounds = 3;
        [SerializeField, Range(4, 7)] int maxGroundsInPool = 4;

        private LinkedList<GroundGenerator> _groundList = new LinkedList<GroundGenerator>();
        static public GroundPlacer Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"Object {nameof(GroundPlacer)} already created. Object name: {gameObject.name}");
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            _groundList.AddFirst(_firstGround);

            for (int i = 0; i < countStartGrounds; i++) 
                PlaceGround();
        }

        public void PlaceGround()
        {
            if (_groundList.Count > maxGroundsInPool)
            {
                GroundGenerator temp = _groundList.First.Value;
                _groundList.RemoveFirst();
                MoveGround(temp);
            }
            else
            {
                CreateGround();
            }
        }

        private void CreateGround()
        {
            GroundGenerator ground = Instantiate(_groundPrefab);
            ground.transform.SetParent(transform);
            MoveGround(ground);
        }

        private void MoveGround(GroundGenerator ground)
        {
            ground.GenerateGround(_groundList.Last.Value.EndPosition);
            _groundList.AddLast(ground);
        }
    }
}