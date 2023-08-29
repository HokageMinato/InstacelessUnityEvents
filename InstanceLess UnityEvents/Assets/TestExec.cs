using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using MethodBinding.Runtime;

[Serializable]
public class VectorUnityEvent : UnityEvent<TestExec> { }


public class TestExec : MonoBehaviour
{
    
    public int totalComputations;

    public FuncBinding<TestExec, float,TestExec> methodBinding;
    public ActionBinding<TestExec> actionBindingTest;

    public float val;
    public VectorUnityEvent ve;


    
    public float GetRoundedValue(TestExec objARg)
    {
        return objARg.GetHashCode();
    }

    object[] valBuff;

    public void GetRounderdwrapper() { GetRoundedValue(this); }



    [ContextMenu("Test")]
    public void Test()
    {

        #region NORMAL_ADD
        Stopwatch stopwatch = new Stopwatch();
        string segmentName = "Native";
        stopwatch.Start();

        for (int i = 0; i < totalComputations; i++)
        {
            GetRoundedValue(this);
        }

        stopwatch.Stop();
        #endregion


        UnityEngine.Debug.Log($"{segmentName} took {stopwatch.ElapsedMilliseconds} ms");



        #region UnityEVENT
        segmentName = "UnityEvent";

        stopwatch.Start();

        for (int i = 0; i < totalComputations; i++)
        {
            ve.Invoke(this);
        }

        stopwatch.Stop();
        #endregion


        UnityEngine.Debug.Log($"{segmentName} took {stopwatch.ElapsedMilliseconds} ms");




        #region SerizCallback_Dynamic
        segmentName = "SerizCallback Dynamic";

        stopwatch.Start();

        for (int i = 0; i < totalComputations; i++)
        {
            vez.Invoke(this);
        }

        stopwatch.Stop();
        #endregion


        UnityEngine.Debug.Log($"{segmentName} took {stopwatch.ElapsedMilliseconds} ms");
        
        #region SerizCallback_Static
        segmentName = "SerizCallback Static";

        stopwatch.Start();

        for (int i = 0; i < totalComputations; i++)
        {
            vez2.Invoke(this);
        }

        stopwatch.Stop();
        #endregion


        UnityEngine.Debug.Log($"{segmentName} took {stopwatch.ElapsedMilliseconds} ms");



        #region UNITYEVENT_INSTANCELESS

        methodBinding.SetTarget(this);

        stopwatch.Reset();
        segmentName = "UnityEvent InstanceLess";
        stopwatch.Start();

        for (int i = 0; i < totalComputations; i++)
        {
            methodBinding.Invoke(this);
            
        }
        #endregion


        UnityEngine.Debug.Log($"{segmentName} took {stopwatch.ElapsedMilliseconds} ms");

    }


}
