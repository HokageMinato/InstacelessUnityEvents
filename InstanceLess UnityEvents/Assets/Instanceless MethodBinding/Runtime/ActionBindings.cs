using System;
using System.Runtime.CompilerServices;
using Object = UnityEngine.Object;

namespace MethodBinding.Runtime
{

    [Serializable]
    public class ActionBinding<TTargetClassType> : MethodBindingBase where TTargetClassType : class
    {
        #region PUBLIC_PROPERTIES
        #endregion

        #region PRIVATE_VARS
        private Action binding;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (System.Action)Delegate.CreateDelegate(typeof(Action), target, _methodName);

        }

        public void Invoke()
        {
#if DEBUG_BUILD
        CheckForEmpty(); 
#endif
            binding.Invoke();
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PROTECTED_METHODS

        #endregion
    }


    [Serializable]
    public class ActionBinding<T1, TTargetClassType> : MethodBindingBase where TTargetClassType : class
    {
        #region PRIVATE_VARS
        private Action<T1> binding;
        private T1 serializedArgument1 = default;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (Action<T1>)Delegate.CreateDelegate(typeof(Action<T1>), _target, _methodName);
            SetArg(ref serializedArgument1, 0);
        }

        public void Invoke(T1 arg1)
        {
            _Invoke(arg1);
        }

        public void Invoke()
        {
            _Invoke(serializedArgument1);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _Invoke(T1 arg1)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1);
        }

        #endregion
    }


    [Serializable]
    public class ActionBinding<T1, T2, TTargetClassType> : MethodBindingBase where TTargetClassType : class
    {
        #region PRIVATE_VARS
        private Action<T1, T2> binding;
        private T1 serializedArgument1= default;
        private T2 serializedArgument2 = default;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (Action<T1, T2>)Delegate.CreateDelegate(typeof(Action<T1, T2>), _target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
        }

        public void Invoke(T1 arg1, T2 arg2)
        {
            _Invoke(arg1, arg2);
        }

        public void Invoke()
        {
            _Invoke(serializedArgument1, serializedArgument2);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _Invoke(T1 arg1, T2 arg2)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2);
        }

        
        #endregion
    }


    [Serializable]
    public class ActionBinding<T1, T2, T3, TTargetClassType> : MethodBindingBase where TTargetClassType : class
    {
        #region PRIVATE_VARS
        private Action<T1, T2, T3> binding;
        private T1 serializedArgument1 = default;
        private T2 serializedArgument2 = default;
        private T3 serializedArgument3 = default;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (Action<T1, T2, T3>)Delegate.CreateDelegate(typeof(Action<T1, T2, T3>), _target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
            SetArg(ref serializedArgument3, 2);
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3)
        {
            _Invoke(arg1, arg2, arg3);
        }

        public void Invoke()
        {
            _Invoke(serializedArgument1, serializedArgument2, serializedArgument3);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _Invoke(T1 arg1, T2 arg2, T3 arg3)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2, arg3);
        }
        #endregion
    }


    [Serializable]
    public class ActionBinding<T1, T2, T3, T4, TTargetClassType> : MethodBindingBase where TTargetClassType : class
    {
        #region PRIVATE_VARS
        private Action<T1, T2, T3, T4> binding;
        private T1 serializedArgument1 = default;
        private T2 serializedArgument2 = default;
        private T3 serializedArgument3 = default;
        private T4 serializedArgument4 = default;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (Action<T1, T2, T3, T4>)Delegate.CreateDelegate(typeof(Action<T1, T2, T3, T4>), _target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
            SetArg(ref serializedArgument3, 2);
            SetArg(ref serializedArgument4, 3);
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            _Invoke(arg1, arg2, arg3, arg4);
        }

        public void Invoke()
        {
            _Invoke(serializedArgument1, serializedArgument2, serializedArgument3, serializedArgument4);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2, arg3, arg4);
        }
        #endregion
    }


    [Serializable]
    public class ActionBinding<T1, T2, T3, T4, T5, TTargetClassType> : MethodBindingBase where TTargetClassType : class
    {
        #region PRIVATE_VARS
        private Action<T1, T2, T3, T4, T5> binding;
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
            binding = (Action<T1, T2, T3, T4, T5>)Delegate.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5>), _target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
            SetArg(ref serializedArgument3, 2);
            SetArg(ref serializedArgument4, 3);
            SetArg(ref serializedArgument5, 4);
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            _Invoke(arg1, arg2, arg3, arg4, arg5);
        }

        public void Invoke()
        {
            _Invoke(serializedArgument1, serializedArgument2, serializedArgument3, serializedArgument4, serializedArgument5);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2, arg3, arg4, arg5);
        }
        #endregion
    }


    [Serializable]
    public class ActionBinding<T1, T2, T3, T4, T5, T6, TTargetClassType> : MethodBindingBase where TTargetClassType : class
    {
        #region PRIVATE_VARS
        private Action<T1, T2, T3, T4, T5, T6> binding;
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
            binding = (Action<T1, T2, T3, T4, T5, T6>)Delegate.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6>), _target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
            SetArg(ref serializedArgument3, 2);
            SetArg(ref serializedArgument4, 3);
            SetArg(ref serializedArgument5, 4);
            SetArg(ref serializedArgument6, 5);
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            _Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public void Invoke()
        {
            _Invoke(serializedArgument1, serializedArgument2, serializedArgument3, serializedArgument4, serializedArgument5, serializedArgument6);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        }
        #endregion
    }


    [Serializable]
    public class ActionBinding<T1, T2, T3, T4, T5, T6, T7, TTargetClassType> : MethodBindingBase where TTargetClassType : class
    {
        #region PRIVATE_VARS
        private Action<T1, T2, T3, T4, T5, T6, T7> binding;
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
            binding = (Action<T1, T2, T3, T4, T5, T6, T7>)Delegate.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7>), _target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
            SetArg(ref serializedArgument3, 2);
            SetArg(ref serializedArgument4, 3);
            SetArg(ref serializedArgument5, 4);
            SetArg(ref serializedArgument6, 5);
            SetArg(ref serializedArgument7, 6);
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            _Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public void Invoke()
        {
            _Invoke(serializedArgument1, serializedArgument2, serializedArgument3, serializedArgument4, serializedArgument5, serializedArgument6, serializedArgument7);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
        #endregion
    }


    [Serializable]
    public class ActionBinding<T1, T2, T3, T4, T5, T6, T7, T8, TTargetClassType> : MethodBindingBase where TTargetClassType : class
    {
        #region PRIVATE_VARS
        private Action<T1, T2, T3, T4, T5, T6, T7, T8> binding;
        private T1 serializedArgument1 = default;
        private T2 serializedArgument2 = default;
        private T3 serializedArgument3 = default;
        private T4 serializedArgument4 = default;
        private T5 serializedArgument5 = default;
        private T6 serializedArgument6 = default;
        private T7 serializedArgument7 = default;
        private T8 serializedArgument8 = default;
        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetClassType target)
        {
            SetTarget(target as Object);
            binding = (Action<T1, T2, T3, T4, T5, T6, T7, T8>)Delegate.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7, T8>), _target, _methodName);
            SetArg(ref serializedArgument1, 0);
            SetArg(ref serializedArgument2, 1);
            SetArg(ref serializedArgument3, 2);
            SetArg(ref serializedArgument4, 3);
            SetArg(ref serializedArgument5, 4);
            SetArg(ref serializedArgument6, 5);
            SetArg(ref serializedArgument7, 6);
            SetArg(ref serializedArgument8, 7);
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            _Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public void Invoke()
        {
            _Invoke(serializedArgument1, serializedArgument2, serializedArgument3, serializedArgument4, serializedArgument5, serializedArgument6, serializedArgument7, serializedArgument8);
        }

        public override void ClearCache()
        {
            binding = null;
        }
        #endregion

        #region PRIVATE_METHODS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
        #endregion
    }

}
