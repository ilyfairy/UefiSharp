using System;

namespace Internal.Runtime.CompilerHelpers;

public class LdTokenHelpers
{
    private static RuntimeTypeHandle GetRuntimeTypeHandle(IntPtr pEEType)
    {
        return new RuntimeTypeHandle(new EETypePtr(pEEType));
    }

    private static unsafe RuntimeMethodHandle GetRuntimeMethodHandle(IntPtr pHandleSignature)
    {
        RuntimeMethodHandle returnValue;
        *(IntPtr*)&returnValue = pHandleSignature;
        return returnValue;
    }

    private static unsafe RuntimeFieldHandle GetRuntimeFieldHandle(IntPtr pHandleSignature)
    {
        //RuntimeFieldHandle returnValue;
        //*(IntPtr*)&returnValue = pHandleSignature;
        //return returnValue;

        return default;
    }

    private static unsafe Type GetRuntimeType(MethodTable* pMT)
    {
        //return Type.GetTypeFromMethodTable(pMT);
        return null;
    }
}
