﻿namespace Net6ODataPoc.Infrastructure.JsonStorage;

public sealed record JsonStorageOptions
{
    public static readonly string SectionName = "JsonStorage";
    public string Path { get; set; } = string.Empty;
}
