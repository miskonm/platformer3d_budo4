using System.Collections.Generic;
using Services.Persistence;
using UnityEngine;

namespace Services.Save
{
    public class SaveLoadService : MonoBehaviour
    {
        private static SaveLoadService _instance;

        public static SaveLoadService Instance => _instance;

        private readonly List<ISaveLoadDataPiece> _saveLoadDataPieces = new List<ISaveLoadDataPiece>();

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void Save()
        {
            foreach (ISaveLoadDataPiece saveLoadDataPiece in _saveLoadDataPieces)
                saveLoadDataPiece.Save(PersistenceService.Instance.Data);

            PersistenceService.Instance.Save();
        }

        public void Load()
        {
            foreach (ISaveLoadDataPiece saveLoadDataPiece in _saveLoadDataPieces)
                saveLoadDataPiece.Load(PersistenceService.Instance.Data);
        }

        public void AddSaveLoadPiece(ISaveLoadDataPiece piece) =>
            _saveLoadDataPieces.Add(piece);

        public void RemoveSaveLoadPiece(ISaveLoadDataPiece piece) =>
            _saveLoadDataPieces.Remove(piece);
    }
}