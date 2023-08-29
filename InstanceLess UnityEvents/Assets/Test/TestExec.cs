using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using MethodBinding.Runtime;

[Serializable]
public class VectorUnityEvent : UnityEvent<TestExec> { }

//[Serializable]
//public class VectorUnityEventSz : SerializableCallback<TestExec,float> { }

public class TestExec : MonoBehaviour
{
    
    public int totalComputations;

   
    
    public ActionBinding<TestExec> actionBindingTest;


    public float val;
    public VectorUnityEvent ve;

    //public VectorUnityEventSz vez;
    
    //public VectorUnityEventSz vez2;

        
    public float GetRoundedValue(TestExec objARg)
    {
        return objARg.GetHashCode();
    }

    

    public void GetRounderdwrapper() { GetRoundedValue(this); }

    public FuncBinding<TestExec, float, TestExec> funcBindingTest;


    [ContextMenu("Test")]
    public void Test()
    {
        Stopwatch stopwatch = new Stopwatch();
        string segmentName;

        #region UNITYEVENT_INSTANCELESS

        funcBindingTest.SetTarget(this);

        stopwatch.Reset();
        segmentName = "UnityEvent InstanceLess";
        stopwatch.Start();

        for (int i = 0; i < totalComputations; i++)
        {
            funcBindingTest.Invoke(this);

        }
        #endregion


        UnityEngine.Debug.Log($"{segmentName} took {stopwatch.ElapsedMilliseconds} ms");


        #region NORMAL_ADD
        stopwatch.Reset();
        segmentName = "Native Method";
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
        //segmentName = "SerizCallback Dynamic";

        //stopwatch.Start();

        //for (int i = 0; i < totalComputations; i++)
        //{
        //    vez.Invoke(this);
        //}

        //stopwatch.Stop();
        #endregion


        //UnityEngine.Debug.Log($"{segmentName} took {stopwatch.ElapsedMilliseconds} ms");
        
        #region SerizCallback_Static
        //segmentName = "SerizCallback Static";

        //stopwatch.Start();

        //for (int i = 0; i < totalComputations; i++)
        //{
        //    vez2.Invoke(this);
        //}

        //stopwatch.Stop();
        #endregion


        //UnityEngine.Debug.Log($"{segmentName} took {stopwatch.ElapsedMilliseconds} ms");



       

    }


}
