using System;
using Services.Persistence;
using Services.Save;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour, ISaveLoadDataPiece
    {
        public string Id { get; private set; }

        public void SetId(string value) =>
            Id = value;

        public void Load(PersistenceData data)
        {
            // TODO: Check if enemy id dead, then dont spawn when needed
        }

        public void Save(PersistenceData data)
        {
        }
    }
}