using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;



namespace MethodBinding.Runtime
{

    /// <summary> An inspector-friendly serializable function </summary>
    [System.Serializable]
    public abstract class MethodBindingBase : ISerializationCallbackReceiver
    {

        #region PUBLIC_VARIABLES
        #endregion

        #region PUBLIC_PROPERTIES
        public Arg[] Arguments { get { return _args; } }
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
        protected void CheckForEmpty()
        {
            if (_target == null || string.IsNullOrEmpty(_methodName))
                throw new Exception($"Trying to build delegate with no method assigned or Target is null");
        }

        protected void SetTarget(Object target)
        {
            _target = target;
            CheckForEmpty();
        }

        protected void SetArg<T>(ref T vari, int argIndex)
        {
            var arg1 = Arguments[argIndex].GetValue();
            if (arg1 != null)
                vari = (T)arg1;
        }
        #endregion

        #region PRIVATE_METHODS

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
    public class Arg
    {
        #region PUBLIC_VARS
        public const int MAX_GENERIC_SUPPORTED = 9;
        public bool boolValue;
        public int intValue;
        public float floatValue;
        public string stringValue;
        public Vector2 vector2Value;
        public Vector2Int vector2IntValue;
        public Vector3 vector3Value;
        public Vector3Int vector3IntValue;
        public Vector4 vector4Value;
        public Rect rectValue;
        public Quaternion quaternionValue;
        public Matrix4x4 matrix4X4Value;
        public Color colorValue;
        public Color32 color32Value;
        public LayerMask layerMaskValue;
        public AnimationCurve animationCurveValue;
        public Gradient gradientValue;


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
                case ArgType.Vector2:
                    return vector2Value;
                case ArgType.Vector3:
                    return vector3Value;
                case ArgType.Vector2Int:
                    return vector2Value;
                case ArgType.Vector3Int:
                    return vector3IntValue;
                case ArgType.Vector4:
                    return vector4Value;
                case ArgType.Rect:
                    return rectValue;
                case ArgType.Quaternion:
                    return quaternionValue;
                case ArgType.Matrix4x4:
                    return matrix4X4Value;
                case ArgType.color:
                    return colorValue;
                case ArgType.color32:
                    return color32Value;
                case ArgType.layerMask:
                    return layerMaskValue;
                case ArgType.animationCurve:
                    return animationCurveValue;
                case ArgType.Gradient:
                    return gradientValue;
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
                case ArgType.Vector2:
                    return typeof(Vector2);
                case ArgType.Vector3:
                    return typeof(Vector3);
                case ArgType.Vector2Int:
                    return typeof(Vector2Int);
                case ArgType.Vector3Int:
                    return typeof(Vector3Int);
                case ArgType.Vector4:
                    return typeof(Vector4);
                case ArgType.Rect:
                    return typeof(Rect);
                case ArgType.Quaternion:
                    return typeof(Quaternion);
                case ArgType.Matrix4x4:
                    return typeof(Matrix4x4);
                case ArgType.color:
                    return typeof(Color);
                case ArgType.color32:
                    return typeof(Color32);
                case ArgType.layerMask:
                    return typeof(LayerMask);
                case ArgType.animationCurve:
                    return typeof(AnimationCurve);
                case ArgType.Gradient:
                    return typeof(Gradient);

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
            else if (type == typeof(Vector2)) return ArgType.Vector2;
            else if (type == typeof(Vector3)) return ArgType.Vector3;
            else if (type == typeof(Vector2Int)) return ArgType.Vector2Int;
            else if (type == typeof(Vector3Int)) return ArgType.Vector3Int;
            else if (type == typeof(Vector4)) return ArgType.Vector4;
            else if (type == typeof(Rect)) return ArgType.Rect;
            else if (type == typeof(Quaternion)) return ArgType.Quaternion;
            else if (type == typeof(Matrix4x4)) return ArgType.Matrix4x4;
            else if (type == typeof(Color)) return ArgType.color;
            else if (type == typeof(Color32)) return ArgType.color32;
            else if (type == typeof(LayerMask)) return ArgType.layerMask;
            else if (type == typeof(AnimationCurve)) return ArgType.animationCurve;
            else if (type == typeof(Gradient)) return ArgType.Gradient;
            else if (typeof(Object).IsAssignableFrom(type)) return ArgType.Object;
            else return ArgType.Unsupported;
        }


        public static bool IsSupported(Type type)
        {
            return FromRealType(type) != ArgType.Unsupported;
        }
        #endregion

        #region INNER_CLASS_DEFINITIONS
        public enum ArgType { Unsupported, Bool, Int, Float, String, Object, Vector2, Vector3, Vector2Int, Vector3Int, Vector4, Rect, Quaternion, Matrix4x4, color, color32, layerMask, animationCurve, Gradient }
        #endregion


        #region EDITOR_HELPERS
#if UNITY_EDITOR

        public static readonly Dictionary<string, string> typeNameResolver = new Dictionary<string, string>
        {
            { "Boolean", "bool" },
            { "Byte", "byte" },
            { "Char", "char" },
            { "Int32", "int" },
            { "Single", "float" },
            { "String", "string" },
            { "Object", "object" }
        };

        public static string ArgTypeName => nameof(argType);
        public static string TypeName => nameof(_typeName);

        public static string ObjectValueName => nameof(objectValue);

        public static Dictionary<ArgType, string> PropertyNameDictionary = new Dictionary<ArgType, string>
        {
        { ArgType.Unsupported, nameof(Unsupported) },
        { ArgType.Bool, nameof(boolValue) },
        { ArgType.Int, nameof(intValue) },
        { ArgType.Float, nameof(floatValue) },
        { ArgType.String, nameof(stringValue) },
        { ArgType.Vector2, nameof(vector2Value) },
        { ArgType.Vector3, nameof(vector3Value) },
        { ArgType.Vector2Int, nameof(vector2IntValue) },
        { ArgType.Vector3Int, nameof(vector3IntValue) },
        { ArgType.Vector4, nameof(vector4Value) },
        { ArgType.Rect, nameof(rectValue) },
        { ArgType.Quaternion, nameof(quaternionValue) },
        { ArgType.Matrix4x4, nameof(matrix4X4Value) },
        { ArgType.color, nameof(colorValue) },
        { ArgType.color32, nameof(color32Value) },
        { ArgType.layerMask, nameof(layerMaskValue) },
        { ArgType.animationCurve, nameof(animationCurveValue) },
        { ArgType.Gradient, nameof(gradientValue) }
        };
#endif
        #endregion

    }



}
