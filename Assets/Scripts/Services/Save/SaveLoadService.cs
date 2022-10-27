using System.Collections.Generic;
using Services.Persistence;
using UnityEngine;

namespace Services.Save
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistenceService _persistenceService;
        
        private readonly List<ISaveLoadDataPiece> _saveLoadDataPieces = new List<ISaveLoadDataPiece>();

        public SaveLoadService(IPersistenceService persistenceService)
        {
            _persistenceService = persistenceService;
        }
        
        public void Save()
        {
            foreach (ISaveLoadDataPiece saveLoadDataPiece in _saveLoadDataPieces)
                saveLoadDataPiece.Save(_persistenceService.Data);
            
            _persistenceService.Save();
        }

        public void Load()
        {
            foreach (ISaveLoadDataPiece saveLoadDataPiece in _saveLoadDataPieces)
                saveLoadDataPiece.Load(_persistenceService.Data);
        }

        public void AddSaveLoadPiece(ISaveLoadDataPiece piece) =>
            _saveLoadDataPieces.Add(piece);

        public void RemoveSaveLoadPiece(ISaveLoadDataPiece piece) =>
            _saveLoadDataPieces.Remove(piece);
    }
}