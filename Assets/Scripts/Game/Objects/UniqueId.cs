using System;
using UnityEngine;

namespace P3D.Game
{
    public class UniqueId : MonoBehaviour
    {
        [SerializeField] private string _id;

        public string Id => _id;

        public void Generate() =>
            _id = $"{name}_{Guid.NewGuid()}";
    }
}