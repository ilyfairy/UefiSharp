namespace System.Runtime.CompilerServices;

public class CompilerFeatureRequiredAttribute(string featureName) : Attribute
{
    public bool IsOptional { get; set; }
    public string FeatureName { get; } = featureName;
}
