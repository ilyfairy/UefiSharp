namespace System.Runtime.CompilerServices;

public class MethodImplAttribute : Attribute
{
    public MethodImplOptions Value { get; }
    public MethodCodeType MethodCodeType;

    public MethodImplAttribute(MethodImplOptions methodImplOptions)
    {
        this.Value = methodImplOptions;
    }

    public MethodImplAttribute(short value)
    {
        this.Value = (MethodImplOptions)value;
    }
}

public enum MethodImplOptions
{
    /// <summary>The method is implemented in unmanaged code.</summary>
    Unmanaged = 4,
    /// <summary>The method cannot be inlined. Inlining is an optimization by which a method call is replaced with the method body.</summary>
    NoInlining = 8,
    /// <summary>The method is declared, but its implementation is provided elsewhere.</summary>
    ForwardRef = 16,
    /// <summary>The method can be executed by only one thread at a time. Static methods lock on the type, whereas instance methods lock on the instance. Only one thread can execute in any of the instance functions, and only one thread can execute in any of a class's static functions.</summary>
    Synchronized = 32,
    /// <summary>The method is not optimized by the just-in-time (JIT) compiler or by native code generation (see Ngen.exe) when debugging possible code generation problems.</summary>
    NoOptimization = 64,
    /// <summary>The method signature is exported exactly as declared.</summary>
    PreserveSig = 128,
    /// <summary>
    ///   <para>The method should be inlined if possible.</para>
    ///   <para>Unnecessary use of this attribute can reduce performance. The attribute might cause implementation limits to be encountered that will result in slower generated code. Always measure performance to ensure it's helpful to apply this attribute.</para>
    /// </summary>
    AggressiveInlining = 256,
    /// <summary>
    ///   <para>The method contains code that should always be optimized for performance.</para>
    ///   <para>It's rarely appropriate to use this attribute. Methods that apply this attribute bypass the first tier of tiered compilation and therefore don't benefit from optimizations that rely on tiered compilation. Those optimizations include dynamic PGO and optimizations based on initialized classes. Use of this attribute might also increase memory use. Always measure performance to ensure it's helpful to apply this attribute.</para>
    /// </summary>
    AggressiveOptimization = 512,
    /// <summary>The call is internal, that is, it calls a method that's implemented within the common language runtime.</summary>
    InternalCall = 4096
}

public enum MethodCodeType
{
    /// <summary>Specifies that the method implementation is in Microsoft intermediate language (MSIL).</summary>
    IL,
    /// <summary>Specifies that the method is implemented in native code.</summary>
    Native,
    /// <summary>Specifies that the method implementation is in optimized intermediate language (OPTIL).</summary>
    OPTIL,
    /// <summary>Specifies that the method implementation is provided by the runtime.</summary>
    Runtime
}