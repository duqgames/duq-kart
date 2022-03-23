using System;
using UnityEngine;

namespace SavingLoading
{
    public class LoadKart : MonoBehaviour
    {
        private GameObject _duckKart;
    
        private void Awake()
        { 
            ES3.Load("duckKart", _duckKart);
            _duckKart.transform.position = Vector3.zero;
        }
    }
}