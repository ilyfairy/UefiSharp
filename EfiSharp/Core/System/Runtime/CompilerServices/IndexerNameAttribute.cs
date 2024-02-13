using System;

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Property, Inherited = true)]
#pragma warning disable CS9113 // Parameter is unread.
public class IndexerNameAttribute(string indexerName) : Attribute;
#pragma warning restore CS9113 // Parameter is unread.
