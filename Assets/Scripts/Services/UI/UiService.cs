using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.UI
{
    public class UiService : IUiService
    {
        private readonly UiFactory _factory;
        private readonly Dictionary<Type, ScreenController> _controllersByType = new();

        public UiService(UiFactory factory)
        {
            _factory = factory;
        }

        public T GetController<T>() where T : ScreenController
        {
            Type key = typeof(T);
            if (_controllersByType.ContainsKey(key))
                return _controllersByType[key] as T;

            return CreateController<T>();
        }

        public void ShowScreen<T>() where T : ScreenController =>
            GetController<T>()?.Show();

        public void HideScreen<T>() where T : ScreenController =>
            GetController<T>()?.Hide();

        private T CreateController<T>() where T : ScreenController
        {
            T controller = _factory.Create<T>();
            if (controller == null)
            {
                Debug.LogError($"Can't create controller for type '{typeof(T)}'");
                return null;
            }
            
            _controllersByType.Add(typeof(T), controller);
            return controller;
        }
    }
}