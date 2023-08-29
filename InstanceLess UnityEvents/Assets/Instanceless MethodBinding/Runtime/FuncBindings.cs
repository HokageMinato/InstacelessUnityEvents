using System;
using Object = UnityEngine.Object;

namespace MethodBinding.Runtime
{

    [Serializable]
public class FuncBinding<T1, TReturnType, TTargetType> : MethodBindingBase where TTargetType : class
{

    #region PUBLIC_PROPERTIES
    //    public static string BindingTypeName => nameof(BindingStat);
    #endregion

    #region PRIVATE_VARS
    private Func<T1, TReturnType> binding;

    
    #endregion

    #region PUBLIC_METHODS
    public void SetTarget(TTargetType target)
    {
        SetTarget(target as Object);
        binding = (System.Func<T1, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, TReturnType>), target, _methodName);

    }

    public TReturnType Invoke(T1 arg1)
    {
    #if DEBUG_BUILD
        CheckForEmpty(); 
    #endif

        return binding.Invoke(arg1);
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
public class FuncBinding<T1, T2, TReturnType, TTargetType> : MethodBindingBase where TTargetType : class
{

    #region PUBLIC_PROPERTIES
    //    public static string BindingTypeName => nameof(BindingStat);
    #endregion

    private Func<T1, T2, TReturnType> binding;

    public void SetTarget(TTargetType target)
    {
        SetTarget(target as Object);
        binding = (Func<T1, T2, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, T2, TReturnType>), target, _methodName);
    }

    public TReturnType Invoke(T1 arg1, T2 arg2)
    {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

        return binding.Invoke(arg1, arg2);
    }

    public override void ClearCache()
    {
        binding = null;
    }
}


[Serializable]
public class FuncBinding<T1, T2, T3, TReturnType, TTargetType> : MethodBindingBase where TTargetType : class
{

    #region PUBLIC_PROPERTIES
    //    public static string BindingTypeName => nameof(BindingStat);
    #endregion

    private Func<T1, T2, T3, TReturnType> binding;

    public void SetTarget(TTargetType target)
    {
        SetTarget(target as Object);
        binding = (Func<T1, T2, T3, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, TReturnType>), target, _methodName);
    }

    public TReturnType Invoke(T1 arg1, T2 arg2, T3 arg3)
    {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

        return binding.Invoke(arg1, arg2, arg3);
    }

    public override void ClearCache()
    {
        binding = null;
    }
}

[Serializable]
public class FuncBinding<T1, T2, T3, T4, TReturnType, TTargetType> : MethodBindingBase where TTargetType : class
{

    #region PUBLIC_PROPERTIES
    //    public static string BindingTypeName => nameof(BindingStat);
    #endregion

    private Func<T1, T2, T3, T4, TReturnType> binding;

    public void SetTarget(TTargetType target)
    {
        SetTarget(target as Object);
        binding = (Func<T1, T2, T3, T4, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, TReturnType>), target, _methodName);
    }

    public TReturnType Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

        return binding.Invoke(arg1, arg2, arg3, arg4);
    }

    public override void ClearCache()
    {
        binding = null;
    }
}

[Serializable]
public class FuncBinding<T1, T2, T3, T4, T5, TReturnType, TTargetType> : MethodBindingBase where TTargetType : class
{

    #region PUBLIC_PROPERTIES
    //    public static string BindingTypeName => nameof(BindingStat);
    #endregion

    private Func<T1, T2, T3, T4, T5, TReturnType> binding;

    public void SetTarget(TTargetType target)
    {
        SetTarget(target as Object);
        binding = (Func<T1, T2, T3, T4, T5, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, T5, TReturnType>), target, _methodName);
    }

    public TReturnType Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

        return binding.Invoke(arg1, arg2, arg3, arg4, arg5);
    }

    public override void ClearCache()
    {
        binding = null;
    }
}

[Serializable]
public class FuncBinding<T1, T2, T3, T4, T5, T6, TReturnType, TTargetType> : MethodBindingBase where TTargetType : class
{

    #region PUBLIC_PROPERTIES
    //    public static string BindingTypeName => nameof(BindingStat);
    #endregion

    private Func<T1, T2, T3, T4, T5, T6, TReturnType> binding;

    public void SetTarget(TTargetType target)
    {
        SetTarget(target as Object);
        binding = (Func<T1, T2, T3, T4, T5, T6, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, T5, T6, TReturnType>), target, _methodName);
    }

    public TReturnType Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

        return binding.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
    }

    public override void ClearCache()
    {
        binding = null;
    }
}

[Serializable]
public class FuncBinding<T1, T2, T3, T4, T5, T6, T7, TReturnType, TTargetType> : MethodBindingBase where TTargetType : class
{

    #region PUBLIC_PROPERTIES
    //    public static string BindingTypeName => nameof(BindingStat);
    #endregion


    private Func<T1, T2, T3, T4, T5, T6, T7, TReturnType> binding;

    public void SetTarget(TTargetType target)
    {
        SetTarget(target as Object);
        binding = (Func<T1, T2, T3, T4, T5, T6, T7, TReturnType>)Delegate.CreateDelegate(typeof(Func<T1, T2, T3, T4, T5, T6, T7, TReturnType>), target, _methodName);
    }

    public TReturnType Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
#if DEBUG_BUILD
        CheckForEmpty();
#endif

        return binding.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }

    public override void ClearCache()
    {
        binding = null;
    }
}


}