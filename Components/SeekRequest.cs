using Unity.Entities;

public struct SeekRequest : IComponentData
{
    public float Value; // Target time in seconds
}
