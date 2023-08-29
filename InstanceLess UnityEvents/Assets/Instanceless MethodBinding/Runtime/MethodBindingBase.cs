using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;



namespace MethodBinding.Runtime
{

    /// <summary> An inspector-friendly serializable function </summary>
    [System.Serializable]
    public abstract class MethodBindingBase : ISerializationCallbackReceiver
    {

        #region PUBLIC_PROPERTIES
        #endregion


        #region PRIVATE_SERIALIED_VARS

        [SerializeField] protected Object _target;
        [SerializeField] protected string _methodName;
        [SerializeField] protected Arg[] _args;
#pragma warning disable 0414
        [SerializeField] private string _typeName;
#pragma warning restore 0414
        [SerializeField] private bool dirty;
        #endregion

        #region PROTECTED_METHODS
#if UNITY_EDITOR
        protected MethodBindingBase()
        {
            _typeName = base.GetType().AssemblyQualifiedName;
        }
#endif



        protected void SetTarget(Object target)
        {
            CheckForEmpty();
            _target = target;
        }
        #endregion

        #region PRIVATE_METHODS
        private void CheckForEmpty()
        {
            if (_target == null || string.IsNullOrEmpty(_methodName))
                throw new Exception($"Trying to build delegate with no method assigned or Target is null");
        }
        #endregion

        #region PUBLIC_METHODS
        public virtual void ClearCache()
        {
            _target = null;
        }


        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            if (dirty)
            {
                ClearCache();
                dirty = false;
            }
#endif
        }

        public void OnAfterDeserialize()
        {
#if UNITY_EDITOR
            _typeName = base.GetType().AssemblyQualifiedName;
#endif
        }
        #endregion

        #region INNER_CLASS_DEFINITIONS

        #endregion

        #region EDITOR_HELPERS
#if UNITY_EDITOR
        public static string MethodName => nameof(_methodName);
        public static string ArgsName => nameof(_args);
#endif
        #endregion
    }



    [System.Serializable]
    public struct Arg
    {
        #region PUBLIC_VARS
        public const int MAX_GENERIC_SUPPORTED = 9;

        public bool boolValue;
        public int intValue;
        public float floatValue;
        public string stringValue;
        public Object objectValue;
        public ArgType argType;
        public string _typeName;
        #endregion

        #region PUBLIC_METHODS
        public object GetValue()
        {
            return GetValue(argType);
        }

        public object GetValue(ArgType type)
        {
            switch (type)
            {
                case ArgType.Bool:
                    return boolValue;
                case ArgType.Int:
                    return intValue;
                case ArgType.Float:
                    return floatValue;
                case ArgType.String:
                    return stringValue;
                case ArgType.Object:
                    return objectValue;
                default:
                    return null;
            }
        }

        public static Type RealType(ArgType type)
        {
            switch (type)
            {
                case ArgType.Bool:
                    return typeof(bool);
                case ArgType.Int:
                    return typeof(int);
                case ArgType.Float:
                    return typeof(float);
                case ArgType.String:
                    return typeof(string);
                case ArgType.Object:
                    return typeof(Object);
                default:
                    return null;
            }
        }

        public static ArgType FromRealType(Type type)
        {
            if (type == typeof(bool)) return ArgType.Bool;
            else if (type == typeof(int)) return ArgType.Int;
            else if (type == typeof(float)) return ArgType.Float;
            else if (type == typeof(String)) return ArgType.String;
            else if (typeof(Object).IsAssignableFrom(type)) return ArgType.Object;
            else return ArgType.Unsupported;
        }

        public static bool IsSupported(Type type)
        {
            return FromRealType(type) != ArgType.Unsupported;
        }
        #endregion

        #region INNER_CLASS_DEFINITIONS
        public enum ArgType { Unsupported, Bool, Int, Float, String, Object }
        #endregion


        #region EDITOR_HELPERS
#if UNITY_EDITOR

        public static string BoolValueName => nameof(boolValue);
        public static string IntValueName => nameof(intValue);
        public static string FloatValueName => nameof(floatValue);
        public static string StringValueName => nameof(stringValue);
        public static string ObjectValueName => nameof(objectValue);
        public static string ArgTypeName => nameof(argType);
        public static string TypeName => nameof(_typeName);

#endif
        #endregion

    }
}