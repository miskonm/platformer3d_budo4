using System;
using UnityEngine;

namespace Services.Persistence
{
    public class PersistenceService : IPersistenceService
    {
        private const string Tag = nameof(PersistenceService);
        private const string DataSaveKey = "Game/PersistenceData";

        public PersistenceData Data { get; private set; }

        public void Bootstrap()
        {
            string json = PlayerPrefs.GetString(DataSaveKey);
            if (string.IsNullOrEmpty(json))
            {
                Data = new PersistenceData();
            }
            else
            {
                try
                {
                    Data = JsonUtility.FromJson<PersistenceData>(json);
                }
                catch (Exception e)
                {
                    Debug.LogError($"[{Tag},{nameof(Bootstrap)}] Can't deserialize data. Exception: {e}");
                    Data = new PersistenceData();
                }
            }
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(Data);
            PlayerPrefs.SetString(DataSaveKey, json);
        }
    }
}