# Instace-lessUnityEvents
An instanceless delegate binder which lets you assign function in editor without requiring instance at the time and providing ability to late initialize the event with target invoker.


Pros:
- Insanely Fast compared UnityEvents, Serializable Callback with near performance to native delegates.
- Allows binding instance latey and lets you assign function at edit time without requiring instance.
- Typesafe by default.
- Ideal for mobile devices and handheld where battery life is concerned.

Cons:
- Binding class need to be resolved at compiletime, This may not be a severe issue but might casue some level of tweaking where assemblies are present.
- The assignment of the functions are limited to the class assigned, child class support will be added later, but it is by design to ensure performance
  and to provide strong reference info during developement.
  
Benchmarks:
Backend: (IL2CPP) 
Compiler Optimisation Configuration: Master


![Bar Graph]( https://i.ibb.co/x8QXS18/One-Plus-Nord-C2.png )


![Bar Graph]( https://i.ibb.co/qsmFCHr/Redmi-9-A-Benchmarks.png )




Method Selection Without Requiring Instance, but restricted to target Type declared in delegate:

![Bar Graph]( https://i.ibb.co/X8SyGXB/1-Method-Selection.png )


Dynamic Argumemnt Draw similar to unity events:

![Bar Graph]( https://i.ibb.co/nw7gYVz/2-Argument-Support-and-Ins-Less-Example.png )


Set Target Invoker at any point in execution with typesafety and minimal performance hit:

![Bar Graph]( https://i.ibb.co/6XcG37j/3-Late-target-Set-Eg.png )

Uses Drawer code from [Siccity.SerialiableCallback](https://github.com/Siccity/SerializableCallback)
