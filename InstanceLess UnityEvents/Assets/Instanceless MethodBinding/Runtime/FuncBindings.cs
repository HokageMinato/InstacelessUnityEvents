using System;
using System.Runtime.CompilerServices;
using Object = UnityEngine.Object;

namespace MethodBinding.Runtime
{

    [Serializable]
    public class FuncBinding<TReturnType, TTargetClassType> : MethodBindingBase where TTargetClassType : Object
    {
        #region PRIVATE_VARS
        private Func<TReturnType> binding;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (Func<TReturnType>)Delegate.CreateDelegate(typeof(Func<TReturnType>), target, _methodName);
        }

        public TReturnType Invoke()
        {
            return _Invoke();
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TReturnType _Invoke()
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            return binding.Invoke();
        }
        #endregion
    }


    [Serializable]
    public class FuncBinding<T1, TReturnType, TTargetClassType> : MethodBindingBase where TTargetClassType : Object
    {

        #region PUBLIC_PROPERTIES
        //    public static string BindingTypeName => nameof(BindingStat);
        #endregion

        #region PRIVATE_VARS
        private Func<T1, TReturnType> binding;
        private T1 serializedArgument1 = default;

        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (System.Func<T1, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, TReturnType>), target, _methodName);
            SetArg(ref serializedArgument1, 0);
        }

        public TReturnType Invoke(T1 arg1)
        {
            return _Invoke(arg1);
        }

        public TReturnType Invoke() 
        {
            return _Invoke(serializedArgument1);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TReturnType _Invoke(T1 arg1)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

           return binding.Invoke(arg1);
        }

        #endregion

    }


    [Serializable]
    public class FuncBinding<T1, T2, T3, TReturnType, TTargetClassType> : MethodBindingBase where TTargetClassType : Object
    {
        #region PRIVATE_VARS
        private Func<T1, T2, T3, TReturnType> binding;
        private T1 serializedArgument1 = default;
        private T2 serializedArgument2 = default;
        private T3 serializedArgument3 = default;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (Func<T1, T2, T3, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, TReturnType>), target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
            SetArg(ref serializedArgument3, 2);
        }

        public TReturnType Invoke(T1 arg1, T2 arg2, T3 arg3)
        {
            return _Invoke(arg1, arg2, arg3);
        }

        public TReturnType Invoke()
        {
            return _Invoke(serializedArgument1, serializedArgument2, serializedArgument3);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TReturnType _Invoke(T1 arg1, T2 arg2, T3 arg3)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            return binding.Invoke(arg1, arg2, arg3);
        }
        #endregion
    }


    [Serializable]
    public class FuncBinding<T1, T2, T3, T4, TReturnType, TTargetClassType> : MethodBindingBase where TTargetClassType : Object
    {
        #region PRIVATE_VARS
        private Func<T1, T2, T3, T4, TReturnType> binding;
        private T1 serializedArgument1 = default;
        private T2 serializedArgument2 = default;
        private T3 serializedArgument3 = default;
        private T4 serializedArgument4 = default;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (Func<T1, T2, T3, T4, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, TReturnType>), target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
            SetArg(ref serializedArgument3, 2);
            SetArg(ref serializedArgument4, 3);
        }

        public TReturnType Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return _Invoke(arg1, arg2, arg3, arg4);
        }

        public TReturnType Invoke()
        {
            return _Invoke(serializedArgument1, serializedArgument2, serializedArgument3, serializedArgument4);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TReturnType _Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            return binding.Invoke(arg1, arg2, arg3, arg4);
        }
        #endregion
    }


    [Serializable]
    public class FuncBinding<T1, T2, T3, T4, T5, TReturnType, TTargetClassType> : MethodBindingBase where TTargetClassType : Object
    {
        #region PRIVATE_VARS
        private Func<T1, T2, T3, T4, T5, TReturnType> binding;
        private T1 serializedArgument1 = default;
        private T2 serializedArgument2 = default;
        private T3 serializedArgument3 = default;
        private T4 serializedArgument4 = default;
        private T5 serializedArgument5 = default;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (Func<T1, T2, T3, T4, T5, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, T5, TReturnType>), target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
            SetArg(ref serializedArgument3, 2);
            SetArg(ref serializedArgument4, 3);
            SetArg(ref serializedArgument5, 4);
        }

        public TReturnType Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return _Invoke(arg1, arg2, arg3, arg4, arg5);
        }

        public TReturnType Invoke()
        {
            return _Invoke(serializedArgument1, serializedArgument2, serializedArgument3, serializedArgument4, serializedArgument5);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TReturnType _Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            return binding.Invoke(arg1, arg2, arg3, arg4, arg5);
        }
        #endregion
    }


    [Serializable]
    public class FuncBinding<T1, T2, T3, T4, T5, T6, TReturnType, TTargetClassType> : MethodBindingBase where TTargetClassType : Object
    {
        #region PRIVATE_VARS
        private Func<T1, T2, T3, T4, T5, T6, TReturnType> binding;
        private T1 serializedArgument1 = default;
        private T2 serializedArgument2 = default;
        private T3 serializedArgument3 = default;
        private T4 serializedArgument4 = default;
        private T5 serializedArgument5 = default;
        private T6 serializedArgument6 = default;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (Func<T1, T2, T3, T4, T5, T6, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, T5, T6, TReturnType>), target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
            SetArg(ref serializedArgument3, 2);
            SetArg(ref serializedArgument4, 3);
            SetArg(ref serializedArgument5, 4);
            SetArg(ref serializedArgument6, 5);
        }

        public TReturnType Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            return _Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public TReturnType Invoke()
        {
            return _Invoke(serializedArgument1, serializedArgument2, serializedArgument3, serializedArgument4, serializedArgument5, serializedArgument6);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TReturnType _Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            return binding.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        }
        #endregion
    }


    [Serializable]
    public class FuncBinding<T1, T2, T3, T4, T5, T6, T7, TReturnType, TTargetClassType> : MethodBindingBase where TTargetClassType : Object
    {
        #region PRIVATE_VARS
        private Func<T1, T2, T3, T4, T5, T6, T7, TReturnType> binding;
        private T1 serializedArgument1 = default;
        private T2 serializedArgument2 = default;
        private T3 serializedArgument3 = default;
        private T4 serializedArgument4 = default;
        private T5 serializedArgument5 = default;
        private T6 serializedArgument6 = default;
        private T7 serializedArgument7 = default;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (Func<T1, T2, T3, T4, T5, T6, T7, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, T5, T6, T7, TReturnType>), target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
            SetArg(ref serializedArgument3, 2);
            SetArg(ref serializedArgument4, 3);
            SetArg(ref serializedArgument5, 4);
            SetArg(ref serializedArgument6, 5);
            SetArg(ref serializedArgument7, 6);
        }

        public TReturnType Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            return _Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public TReturnType Invoke()
        {
            return _Invoke(serializedArgument1, serializedArgument2, serializedArgument3, serializedArgument4, serializedArgument5, serializedArgument6, serializedArgument7);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TReturnType _Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            return binding.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
        #endregion
    }


}
