${
    using Typewriter.Extensions.WebApi;

    string ApiName(Class c)
    {
        return c.Name + "Client";
    }

    string ApiAttribute(Attribute a)
    {
        if(a.Name.ToLower().Contains("http"))
            return a.Name.Substring(4).ToUpper();
        else return "GET";
    }

    string checkType(Property t){
        if(t.Type.IsEnumerable){
        return "je enumerable";
        }
        else    {
        return "nie je enumerable";
        }
    }

    string GetTSClassFromClass(Class c){
        var v = "export class " + c.Name + " {\n";
            foreach( var prop in c.Properties)
            {
                GetTSPropFromProp(prop);
            }
            v += "}";
        return v;
    }

    string GetTSClassFromProp(String className, IEnumerable<Property> properties){
        var v = "export class " + className + " {\n";
            foreach( var prop in properties)
            {
                GetTSPropFromProp(prop);
            }
            v += "}";
        return v;
    }

    string GetTSPropFromProp(Property prop){
        return prop.name +" : " + prop.Type + "\n";
    }


   

    bool PropIsClassType(Property prop){
        if(!prop.Type.IsPrimitive){
            if(prop.Type.IsEnumerable){
                foreach(var enumerableProp in prop.Type.TypeArguments){
                    if(!enumerableProp.IsPrimitive){
                        
                    }
                }
            }
            return false;
        }
        return true;
    }

    bool TestPropCollection(PropertyCollection props){
        var v = props.Any(p => (!p.Type.IsPrimitive));

        foreach(var prop in props){
            if(!prop.Type.IsPrimitive){
                if(prop.Type.IsEnumerable){
                }
            }
        }
        return false;
    }


    string GetPropertyNestedTypeClass(Property t){
         var v ="";
         if (t.Type.IsEnumerable) {
             foreach(var subtypes in t.Type.TypeArguments){
                if(subtypes.IsPrimitive)
                {
                    v += subtypes.name + " : " + subtypes.ToString();
                }
                else {
                    v += GetTSClassFromProp(subtypes.Name, subtypes.Properties);
                }
             }
         }
         else if(!t.Type.IsPrimitive){
            v += GetTSClassFromProp(t.Type.Name, t.Type.Properties);
         }

         return v; 
    }



    IEnumerable<Type> AllApplicableTypeClasses(Class cls)
    {
        return AllApplicableTypes(cls, false);
    }

    IEnumerable<Type> AllApplicableTypeEnums(Class cls)
    {
        return AllApplicableTypes(cls, true);
    }

    IEnumerable<Type> AllApplicableTypes(Class cls, bool isEnum)
    {
        var retVal = new Dictionary<string, Type>();
        foreach (var method in cls.Methods)
        {
            foreach (var parameter in method.Parameters)
            {
                AllApplicableTypesOfTypeRec(parameter.Type, retVal);
            }

            AllApplicableTypesOfTypeRec(method.Type, retVal); 
        } 
       
        var retList = retVal.Select(p => p.Value).Where(p => !p.Name.Contains("ActionResult") && !p.FullName.Contains("System.Collections.Generic") && TypeClassName(p) != "any");;
        if (isEnum) {
            return retList.Where(p => p.IsEnum == true).Distinct();
        } else {
            return retList.Where(p => p.IsEnum == false);
        }
    }

    void AllApplicableTypesOfTypeRec(Type t,Dictionary<string, Type> typeList)
    {     
        if (t.IsEnumerable && t.TypeArguments != null && t.TypeArguments.Count > 0) {
            t = t.TypeArguments[0];
        }

        if (!ShouldRecursivelyIterateType(t)) {
            return;
        }

        if (t.Name == "void" || t.Name == "any" || t.Name == "JArray") {
            return;
        }

        if (typeList.ContainsKey(t.FullName)) {
            return;
        }

        //Check if nullable not already included
        if (t.IsNullable && typeList.ContainsKey(t.FullName.Substring(0, t.FullName.Length-1))) {
            return;
        }
        
        //Check if nullable not already present
        if (!t.IsNullable && typeList.ContainsKey(t.FullName + "?")) {
            return;
        }

        typeList[t.FullName] = t;
        foreach (var prop in GetPropertyList(t, null,null))
        {
            AllApplicableTypesOfTypeRec(prop.Type, typeList);
        }
    }

    bool ShouldRecursivelyIterateType(Type t) 
    {
        if (t.IsEnum) {
            return true;
        }

        return !t.IsPrimitive && !t.IsDate;
    }

    string TypeClassName(Type t)
    {
        return t.Name.Replace("[]","").Replace("?","");
    }


    IEnumerable<Property> AllProperties(Type t)
    {
        return GetPropertyList(t, null, null);
    }

    IEnumerable<Property> GetPropertyList(Type t, Class c, Dictionary<string, Property> propMap)
    {
        if (propMap == null) {
            propMap = new Dictionary<string, Property>();
        }

        if (c != null ) {
            if (c.BaseClass != null) {
                GetPropertyList(null, c.BaseClass, propMap);
            }

            foreach (var classProp in c.Properties)
            {
                if (!propMap.ContainsKey(classProp.Name))
                {
                    propMap[classProp.Name] = classProp;
                }
            }
        }

        if (t != null)
        {
            if (t.BaseClass != null) {
                GetPropertyList(null, t.BaseClass, propMap);
            }

            foreach (var typeProp in t.Properties)
            {
                if (!propMap.ContainsKey(typeProp.Name))
                {
                    var addProp = true;
                    if (typeProp.Attributes != null)
                    {
                        foreach (var propAttr in typeProp.Attributes)
                        {
                            if (propAttr.Name == "JsonIgnore")
                            {
                                addProp = false;
                                break;
                            }
                        }
                    }

                    if (addProp)
                    {
                        propMap[typeProp.Name] = typeProp;
                    }
                }
            }
        }

        return propMap.Select(p => p.Value);
    }

    string ApiMethodName(Method m)
    {
        if (m.Parameters?.Count > 0)
        {
            return m.name;
        }
        else 
        {
            return "getWithoutParams";
        }
    }

    string AjaxProviderMethod(Method m)
    {
        var fullName = m.FullName;
        var splitArr = fullName.Split('.');
        var nameLower = m.Name.ToLowerInvariant();
        var apiPreffix = "AjaxProvider.api";

        if (nameLower == "get") {
            return apiPreffix + "Get";
        } else if (nameLower == "post") {
            return apiPreffix + "Post";
        } else if (nameLower == "delete") {
           return apiPreffix + "Delete";
        }

        if (m.Attributes != null) {
            foreach (var attr in m.Attributes)
            {
                if (attr == "HttpGet") {
                    return apiPreffix + "Get";
                }

                if (attr == "HttpPost") {
                    return apiPreffix + "Post";
                }

                if (attr == "HttpDelete") {
                    return apiPreffix + "Delete";
                }
            }
        }

        return "AjaxProvider.api" + m.Name;
    }

    string ControllerName(Method m)
    {
        const string CONTROLLER_SUFFIX = "Controller";
        var splitArr = m.FullName.Split('.');
        var baseVal = splitArr[splitArr.Length-2];
        var retVal = baseVal.Substring(0, baseVal.Length - CONTROLLER_SUFFIX.Length);

        if (m.Attributes != null)
        {
            foreach (var attr in m.Attributes)
            {
                if (attr.Name == "Route")
                {
                    if (!attr.Value.StartsWith("api"))
                    {
                        retVal = retVal + "/" + attr.Value;
                    }
                    else
                    {
                        retVal = attr.Value;
                    }

                    break;
                }
            }
        }

        return retVal;

    }

    string ParameterDeclaration(Method m)
    {
        if (m.Parameters?.Count > 0)
        {
            return "data";
        }
        else
        {
            return "null";
        }
    }

    string ControllerClassName(Class c)
    {
        return c.Name.Replace("Controller", "Client");
    }

    string ReturnType(Method m) 
    {
        var typeName = m.Type.Name;
        if (typeName == "IActionResult" || typeName == "ActionResult") {
            return "any";
        } else if (typeName.StartsWith("ActionResult<")) {
            return typeName.Substring(13, typeName.Length - 14);
        }

        return m.Type.Name == "IHttpActionResult" ? "void" : m.Type.Name;
    }

    
}
// this file is autogenerated by typewriter (used Template.tst file to generate)

import { AjaxProvider } from "../scripts/ajax";

$Classes(:ApiControllerBase)[
$AllApplicableTypeClasses[
export class $Name {$AllProperties[
    $Name: $Type = null;]
}]

$AllApplicableTypeEnums[
export class $Name {$AllProperties[
    $Name: $Type = null;]
}]

export default class $ControllerClassName {
$Methods[
    $ApiMethodName<$Parameters[TArgs extends $Type, ]TResult extends $ReturnType>($Parameters[data: TArgs]): Promise<TResult> {
        return $AjaxProviderMethod("$ControllerName", $ParameterDeclaration);
    }
}]
]