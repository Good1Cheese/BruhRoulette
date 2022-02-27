using System;

public interface IDoneable
{
    public Action Done { get; set; }
}