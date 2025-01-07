using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public interface IService
    {
    }

    public class AllServices
    {

        private static AllServices _instance;

        public static AllServices Container => _instance ??= new AllServices();

        public void RegisterSingle<TService>(TService service) where TService : IService
        {
            Implementation<IService>.ServiceInstance = service;
        }

        public TService Single<TService>() where TService : IService
        {
            return Implementation<TService>.ServiceInstance;
        }

        private class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}