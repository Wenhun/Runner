using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.LevelGeneration
{
    public class GroundPlacer : MonoBehaviour
    {
        [Header("Grounds Prefabs")]
        [SerializeField] GroundGenerator groundPrefab;
        [SerializeField] GroundGenerator firstGround;

        [Header("Creation Settings")]
        [SerializeField, Range(1, 4)] int countStartGrounds;
        [SerializeField, Range(4, 7)] int maxGroundsInPool;

        LinkedList<GroundGenerator> groundPool = new LinkedList<GroundGenerator>();

        void Awake()
        {
            groundPool.AddFirst(firstGround);

            for (int i = 0; i < countStartGrounds; i++) NewGround();
        }

        void Placer(GroundGenerator ground)
        {
            ground.GenerateGround(groundPool.Last.Value.EndPosition);
            groundPool.AddLast(ground);
        }

        public void NewGround()
        {
            if (groundPool.Count > maxGroundsInPool)
            {
                GroundGenerator temp = groundPool.First.Value;
                groundPool.RemoveFirst();
                Placer(temp);
            }
            else
            {
                Placer(Instantiate(groundPrefab));
            }
        }
    }
}