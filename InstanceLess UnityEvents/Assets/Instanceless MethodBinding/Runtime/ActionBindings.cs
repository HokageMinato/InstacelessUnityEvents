using System;
using Object = UnityEngine.Object;

namespace MethodBinding.Runtime
{

    [Serializable]
    public class ActionBinding<TTargetType> : MethodBindingBase where TTargetType : class
    {
        #region PUBLIC_PROPERTIES
        //    public static string BindingTypeName => nameof(BindingStat);
        #endregion

        #region PRIVATE_VARS
        private Action binding;


        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetType target)
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
    public class ActionBinding<T1, TTargetType> : MethodBindingBase where TTargetType : class
    {

        #region PUBLIC_PROPERTIES
        //    public static string BindingTypeName => nameof(BindingStat);
        #endregion

        #region PRIVATE_VARS
        private Action<T1> binding;


        #endregion

        #region PUBLIC_METHODS
        public void SetTarget(TTargetType target)
        {
            SetTarget(target as Object);
            binding = (System.Action<T1>)Delegate.CreateDelegate(typeof(Action<T1>), target, _methodName);

        }

        public void Invoke(T1 arg1)
        {
#if DEBUG_BUILD
        CheckForEmpty(); 
#endif

            binding.Invoke(arg1);
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
    public class ActionBinding<T1, T2, TTargetType> : MethodBindingBase where TTargetType : class
    {

        #region PUBLIC_PROPERTIES
        //    public static string BindingTypeName => nameof(BindingStat);
        #endregion

        private Action<T1, T2> binding;

        public void SetTarget(TTargetType target)
        {
            SetTarget(target as Object);
            binding = (Action<T1, T2>)Delegate.CreateDelegate(typeof(Action<T1, T2>), target, _methodName);
        }

        public void Invoke(T1 arg1, T2 arg2)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2);
        }

        public override void ClearCache()
        {
            binding = null;
        }
    }

    [Serializable]
    public class ActionBinding<T1, T2, T3, TTargetType> : MethodBindingBase where TTargetType : class
    {

        #region PUBLIC_PROPERTIES
        //    public static string BindingTypeName => nameof(BindingStat);
        #endregion

        private Action<T1, T2, T3> binding;

        public void SetTarget(TTargetType target)
        {
            SetTarget(target as Object);
            binding = (Action<T1, T2, T3>)Delegate.CreateDelegate(typeof(Action<T1, T2, T3>), target, _methodName);
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2, arg3);
        }

        public override void ClearCache()
        {
            binding = null;
        }
    }

    [Serializable]
    public class ActionBinding<T1, T2, T3, T4, TTargetType> : MethodBindingBase where TTargetType : class
    {

        #region PUBLIC_PROPERTIES
        //    public static string BindingTypeName => nameof(BindingStat);
        #endregion

        private Action<T1, T2, T3, T4> binding;

        public void SetTarget(TTargetType target)
        {
            SetTarget(target as Object);
            binding = (Action<T1, T2, T3, T4>)Delegate.CreateDelegate(typeof(Action<T1, T2, T3, T4>), target, _methodName);
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2, arg3, arg4);
        }

        public override void ClearCache()
        {
            binding = null;
        }
    }

    [Serializable]
    public class ActionBinding<T1, T2, T3, T4, T5, TTargetType> : MethodBindingBase where TTargetType : class
    {

        #region PUBLIC_PROPERTIES
        //    public static string BindingTypeName => nameof(BindingStat);
        #endregion

        private Action<T1, T2, T3, T4, T5> binding;

        public void SetTarget(TTargetType target)
        {
            SetTarget(target as Object);
            binding = (Action<T1, T2, T3, T4, T5>)Delegate.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5>), target, _methodName);
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2, arg3, arg4, arg5);
        }

        public override void ClearCache()
        {
            binding = null;
        }
    }

    [Serializable]
    public class ActionBinding<T1, T2, T3, T4, T5, T6, TTargetType> : MethodBindingBase where TTargetType : class
    {

        #region PUBLIC_PROPERTIES
        //    public static string BindingTypeName => nameof(BindingStat);
        #endregion

        private Action<T1, T2, T3, T4, T5, T6> binding;

        public void SetTarget(TTargetType target)
        {
            SetTarget(target as Object);
            binding = (Action<T1, T2, T3, T4, T5, T6>)Delegate.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6>), target, _methodName);
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public override void ClearCache()
        {
            binding = null;
        }
    }

    [Serializable]
    public class ActionBinding<T1, T2, T3, T4, T5, T6, T7, TTargetType> : MethodBindingBase where TTargetType : class
    {

        #region PUBLIC_PROPERTIES
        //    public static string BindingTypeName => nameof(BindingStat);
        #endregion


        private Action<T1, T2, T3, T4, T5, T6, T7> binding;

        public void SetTarget(TTargetType target)
        {
            SetTarget(target as Object);
            binding = (Action<T1, T2, T3, T4, T5, T6, T7>)Delegate.CreateDelegate(typeof(Action<T1, T2, T3, T4, T5, T6, T7>), target, _methodName);
        }

        public void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

            binding.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public override void ClearCache()
        {
            binding = null;
        }
    }
}