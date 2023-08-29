using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using MethodBinding.Runtime;


namespace MethodBinding.EditorExtension
{
    [CustomPropertyDrawer(typeof(TargetConstraintAttribute))]
    [CustomPropertyDrawer(typeof(MethodBindingBase), true)]
    public class MethodBindingDrawer : PropertyDrawer
    {

        #region PRIVATE_VARS
        private const string DebugMethodName = "";
        private const string FUNC_STR = "FuncBinding";
        private static readonly GUIContent NALabel = new GUIContent("n/a");
        private static readonly Dictionary<string, string> typeNameResolver = new Dictionary<string, string>
        {
            { "Boolean", "bool" },
            { "Byte", "byte" },
            { "SByte", "sbyte" },
            { "Char", "char" },
            { "Int16", "short" },
            { "UInt16", "ushort" },
            { "Int32", "int" },
            { "UInt32", "uint" },
            { "Int64", "long" },
            { "UInt64", "ulong" },
            { "Single", "float" },
            { "Double", "double" },
            { "Decimal", "decimal" },
            { "String", "string" },
            { "Object", "object" }
        };
        #endregion

        #region UNITY_CALLBAKCS

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float lineheight = EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
            SerializedProperty argProps = property.FindPropertyRelative(MethodBindingBase.ArgsName);

            float height = lineheight + lineheight;

            height += argProps.arraySize * lineheight;
            height += 8;
            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.serializedObject.ApplyModifiedProperties();

#if UNITY_2019_1_OR_NEWER
            GUI.Box(position, "");
#else
		GUI.Box(position, "", (GUIStyle)
			"flow overlay box");
#endif

            position.y += 4;
            
            property.serializedObject.Update();
            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.indentLevel++;
            // Draw label
            Rect pos = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            EditorGUI.indentLevel--;

            Rect targetRect = new Rect(pos.x, pos.y, pos.width, EditorGUIUtility.singleLineHeight);
            Type targetType;

            if (attribute != null && attribute is TargetConstraintAttribute)
            {
                targetType = (attribute as TargetConstraintAttribute).targetType;
            }

            if (!CanProceedToDraw())
                return;

            targetType = GetClassTypeGenericArgument();

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel++;

            string selectedMethodName = GetSelectedMethodName(property);
            Type[] argTypes = GetSelectedMethodArguments(property);

            // Get active method
            MethodInfo selectedMethod = GetMethodInfoOfSelectedMethod(targetType, selectedMethodName, argTypes);

            Rect methodRect = new Rect(position.x, targetRect.max.y + EditorGUIUtility.standardVerticalSpacing, position.width, EditorGUIUtility.singleLineHeight);
            // Method select button
            Rect labelRect = EditorGUI.PrefixLabel(methodRect, GUIUtility.GetControlID(FocusType.Passive), new GUIContent("Dynamic Bind"));
            GUIContent methodlabel = GenerateMethodLabel(selectedMethod);
            if (EditorGUI.DropdownButton(labelRect, methodlabel, FocusType.Keyboard))
            {
                DrawMethodDropdown(property, targetType);
            }
            if (selectedMethod != null)
            {
                DrawMethodInputRect(position, property, selectedMethod, methodRect);
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
            property.serializedObject.ApplyModifiedProperties();
        }

        private Type[] GetSelectedMethodArguments(SerializedProperty property)
        {

            // Get args

            return GetArgTypes(property.FindPropertyRelative(MethodBindingBase.ArgsName));
        }

        private static string GetSelectedMethodName(SerializedProperty property)
        {
            // Get method name
            SerializedProperty selectedMethodProperty = property.FindPropertyRelative(MethodBindingBase.MethodName);
            string selectedMethodName = selectedMethodProperty.stringValue;
            return selectedMethodName;
        }

        private static void DrawMethodInputRect(Rect position, SerializedProperty property,  MethodInfo activeMethod, Rect methodRect)
        {
            SerializedProperty argProps = property.FindPropertyRelative(MethodBindingBase.ArgsName);

            ParameterInfo[] activeParameters = activeMethod.GetParameters();
            Rect argRect = new Rect(position.x, methodRect.max.y + EditorGUIUtility.standardVerticalSpacing, position.width, EditorGUIUtility.singleLineHeight);
            string[] types = new string[argProps.arraySize];
            for (int i = 0; i < types.Length; i++)
            {
                SerializedProperty argProp = argProps.FindPropertyRelative("Array.data[" + i + "]");
                GUIContent argLabel = new GUIContent(ObjectNames.NicifyVariableName(activeParameters[i].Name));

                EditorGUI.BeginChangeCheck();
                switch ((Arg.ArgType)argProp.FindPropertyRelative(Arg.ArgTypeName).enumValueIndex)
                {
                    case Arg.ArgType.Bool:
                        EditorGUI.PropertyField(argRect, argProp.FindPropertyRelative(Arg.BoolValueName), argLabel);
                        break;

                    case Arg.ArgType.Int:
                        EditorGUI.PropertyField(argRect, argProp.FindPropertyRelative(Arg.IntValueName), argLabel);
                        break;

                    case Arg.ArgType.Float:
                        EditorGUI.PropertyField(argRect, argProp.FindPropertyRelative(Arg.FloatValueName), argLabel); ;
                        break;

                    case Arg.ArgType.String:
                        EditorGUI.PropertyField(argRect, argProp.FindPropertyRelative(Arg.StringValueName), argLabel);
                        break;

                    case Arg.ArgType.Object:

                        SerializedProperty typeProp = argProp.FindPropertyRelative(Arg.TypeName);
                        SerializedProperty objProp = argProp.FindPropertyRelative(Arg.ObjectValueName);

                        if (typeProp != null)
                        {
                            Type objType = Type.GetType(typeProp.stringValue, false);
                            EditorGUI.BeginChangeCheck();

                            Object obj = objProp.objectReferenceValue;
                            obj = EditorGUI.ObjectField(argRect, argLabel, obj, objType, true);
                            if (EditorGUI.EndChangeCheck())
                            {
                                objProp.objectReferenceValue = obj;
                            }
                        }
                        else
                        {
                            EditorGUI.PropertyField(argRect, objProp, argLabel);
                        }
                        break;
                }
                if (EditorGUI.EndChangeCheck())
                {
                    property.FindPropertyRelative("dirty").boolValue = true;
                }
                argRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }
        }

        #endregion

        #region PRIVATE_METHODS

        private GUIContent GenerateMethodLabel(MethodInfo activeMethod)
        {
            GUIContent methodlabel = NALabel;

            if (activeMethod != null)
                methodlabel = new GUIContent($"{activeMethod.DeclaringType}.{activeMethod.Name}({GenerateParameterString(activeMethod.GetParameters())})");

            return methodlabel;
        }

        private Type GetClassTypeGenericArgument()
        {
            var genArgsRaw = GetGenericArguments();
            return genArgsRaw[genArgsRaw.Length - 1];
        }

        private bool CanProceedToDraw()
        {
            if (GetGenericArguments().Length < 2 && IsFuncBinding())
            {
                Debug.Log("No Gen Arg");
                return false;
            }

            if (GetClassTypeGenericArgument() == typeof(MonoScript))
            {
                Debug.Log("MScr Arg");
                return false;
            }

            return true;
        }

        private Type[] GetGenericArguments()
        {
            if (fieldInfo.FieldType.IsArray && fieldInfo.FieldType.GetArrayRank() == 1)
                return fieldInfo.FieldType.GetElementType().GetGenericArguments();

            return fieldInfo.FieldType.GetGenericArguments();
        }


        private Type[] GetGenericArgumentsWithoutClassType()
        {
            var genArgsRaw = GetGenericArguments();

            var withoutClassTypeGenArgs = new Type[genArgsRaw.Length - 1];
            Array.Copy(genArgsRaw, 0, withoutClassTypeGenArgs, 0, withoutClassTypeGenArgs.Length);



            return withoutClassTypeGenArgs;
        }

        private bool IsFuncBinding()
        {
            return fieldInfo.FieldType.Name.Contains(FUNC_STR);
        }

        private void DrawMethodDropdown(SerializedProperty property, Type targetType)
        {
            Type returnType = null;

            Type[] argTypes = new Type[0];

            Type[] genericTypes = GetGenericArgumentsWithoutClassType();



            //TODO Need revisit for event!
            // SerializableEventBase is always void return type

            if (IsFuncBinding())
            {
                returnType = genericTypes[genericTypes.Length - 1];

                if (genericTypes.Length > 1)
                {
                    argTypes = new Type[genericTypes.Length - 1];
                    Array.Copy(genericTypes, argTypes, genericTypes.Length - 1);
                }
            }
            else
            {
                returnType = typeof(void);
                if (genericTypes.Length > 0)
                {
                    argTypes = new Type[genericTypes.Length];
                    Array.Copy(genericTypes, argTypes, genericTypes.Length);
                }


            }

            List<MenuItem> menuItems = new List<MenuItem>();

            MethodInfo[] methods = targetType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            Debug.Log(methods.FirstOrDefault(x => x.Name.Contains(DebugMethodName)) == null);

            for (int i = 0; i < methods.Length; i++)
            {
                MethodInfo methodInfo = methods[i];

                // Skip methods with wrong return type
                if (returnType != null && methodInfo.ReturnType != returnType)
                {
                    if (methods[i].Name.Contains(DebugMethodName))
                        Debug.Log("SKipped at return type mismatch");

                    continue;
                }

                // Skip methods with null return type
                // if (method.ReturnType == typeof(void)) continue;
                // Skip generic methods
                if (methodInfo.IsGenericMethod)
                {
                    if (methods[i].Name.Contains(DebugMethodName))
                        Debug.Log("SKipped at since generic met");

                    continue;
                }

                Type[] parms = methodInfo.GetParameters().Select(x => x.ParameterType).ToArray();

                // Skip methods with more than defined args
                if (parms.Length > Arg.MAX_GENERIC_SUPPORTED)
                {
                    if (methods[i].Name.Contains(DebugMethodName))
                        Debug.Log("SKipped at paramLength Check");

                    continue;
                }

                // Skip methods with unsupported args
                if (parms.Any(x => !Arg.IsSupported(x)))
                {
                    if (methods[i].Name.Contains(DebugMethodName))
                        Debug.Log("SKipped at arg not supp");

                    continue;
                }

                #region DEBUGGING
                string argTy = "";
                foreach (var item in argTypes)
                {
                    argTy += item.Name + ",";
                }

                string sargTy = "";
                foreach (var item in parms)
                {
                    sargTy += item.Name + ",";
                }

                string seqChe = ($"{argTy}-{sargTy} -- {methodInfo.Name}");
                #endregion

                if ((IsFuncBinding() && argTypes.Length == 0) ||
                    !Enumerable.SequenceEqual(argTypes, parms))
                {
                    if (methods[i].Name.Contains(DebugMethodName))
                        Debug.Log("SKipped at seqCheck" + seqChe);
                    continue;
                }

                string parameterString = GenerateParameterString(methods[i].GetParameters());
                parameterString = $"{methodInfo.Name}({parameterString})";
                menuItems.Add(new MenuItem(methods[i].DeclaringType.Name, parameterString, () => SetMethod(property, methodInfo)));
            }


            // Construct and display context menu
            GenericMenu menu = new GenericMenu();
            if (menuItems.Count > 0)
            {
                string[] paths = menuItems.GroupBy(x => x.path).Select(x => x.First().path).ToArray();

                for (int i = 0; i < menuItems.Count; i++)
                {
                    menu.AddItem(menuItems[i].label, false, menuItems[i].action);
                }
            }

            if (menu.GetItemCount() == 0)
                menu.AddDisabledItem(new GUIContent("No methods Available'" + GetCommonTypeName(returnType.Name) + "'"));

            menu.ShowAsContext();
        }

        private string GenerateParameterString(ParameterInfo[] parameterInfoList)
        {
            string parameterTypeString;
            List<string> parameterTypes = new List<string>();

            foreach (var parameterInfo in parameterInfoList)
                parameterTypes.Add(GetCommonTypeName(parameterInfo.ParameterType.Name));

            parameterTypeString = string.Join(", ", parameterTypes);
            return parameterTypeString;
        }

        private string GetCommonTypeName(string name)
        {
            if (typeNameResolver.ContainsKey(name))
                return typeNameResolver[name];

            return name;
        }

        private MethodInfo GetMethodInfoOfSelectedMethod(Type classType, string methodName, Type[] types)
        {
            MethodInfo activeMethod = classType.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, CallingConventions.Any, types, null);
            return activeMethod;
        }

        private Type[] GetArgTypes(SerializedProperty argsProp)
        {
            Type[] types = new Type[argsProp.arraySize];
            for (int i = 0; i < argsProp.arraySize; i++)
            {
                SerializedProperty argProp = argsProp.GetArrayElementAtIndex(i);
                SerializedProperty typeNameProp = argProp.FindPropertyRelative(Arg.TypeName);
                if (typeNameProp != null) types[i] = Type.GetType(typeNameProp.stringValue, false);
                if (types[i] == null) types[i] = Arg.RealType((Arg.ArgType)argProp.FindPropertyRelative(Arg.ArgTypeName).enumValueIndex);
            }
            return types;
        }

        private void SetMethod(SerializedProperty property, /*UnityEngine.Object target,*/ MethodInfo methodInfo/*, bool dynamic*/)
        {
            SerializedProperty methodProp = property.FindPropertyRelative(MethodBindingBase.MethodName);
            methodProp.stringValue = methodInfo.Name;

            SerializedProperty argProp = property.FindPropertyRelative(MethodBindingBase.ArgsName);
            ParameterInfo[] parameters = methodInfo.GetParameters();
            argProp.arraySize = parameters.Length;
            for (int i = 0; i < parameters.Length; i++)
            {
                argProp.FindPropertyRelative("Array.data[" + i + $"].{Arg.ArgTypeName}").enumValueIndex = (int)Arg.FromRealType(parameters[i].ParameterType);
                argProp.FindPropertyRelative("Array.data[" + i + $"].{Arg.TypeName}").stringValue = parameters[i].ParameterType.AssemblyQualifiedName;
            }
            property.FindPropertyRelative("dirty").boolValue = true;
            property.serializedObject.ApplyModifiedProperties();
            property.serializedObject.Update();
        }
        #endregion

        #region INNER_CLASS_DEFS
        private class MenuItem
        {
            public GenericMenu.MenuFunction action;
            public string path;
            public GUIContent label;

            public MenuItem(string path, string name, GenericMenu.MenuFunction action)
            {
                this.action = action;
                label = new GUIContent(name);
                this.path = path;
            }
        }
        #endregion
       
    }
}