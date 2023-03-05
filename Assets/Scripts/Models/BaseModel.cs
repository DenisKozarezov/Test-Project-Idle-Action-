using System;
using UnityEngine;

namespace Core.Models
{
    public abstract class BaseModel : ScriptableObject, IEquatable<BaseModel>   
    {
        [field: Header("Common")]
        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public string DisplayName { get; private set; }
        [field: SerializeField, TextArea] public string Description { get; private set; }

        private void OnValidate()
        {
            if (string.IsNullOrEmpty(DisplayName))
            {
                DisplayName = name;
            }
        }

        public bool Equals(BaseModel other)
        {
            if (other == null) return false;
            return ID == other.ID;
        }
    }
}