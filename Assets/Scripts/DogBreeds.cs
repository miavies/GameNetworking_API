using Newtonsoft.Json;
using System;
using System.Collections.Generic;

[Serializable]
public class DogBreedAPI
{
    [JsonProperty("data")]
    public List<DogBreedData> Data;
}

[Serializable]
public class DogBreedData
{
    [JsonProperty("id")]
    public string Id;

    [JsonProperty("type")]
    public string Type;

    [JsonProperty("attributes")]
    public DogAttributes Attributes;
}

[Serializable]
public class DogAttributes
{
    [JsonProperty("name")]
    public string Name;

    [JsonProperty("description")]
    public string Description;

    [JsonProperty("life")]
    public DogLife Life;

    [JsonProperty("male_weight")]
    public DogWeight MaleWeight;

    [JsonProperty("female_weight")]
    public DogWeight FemaleWeight;

    [JsonProperty("hypoallergenic")]
    public bool Hypoallergenic;
}

[Serializable]
public class DogLife 
{
    [JsonProperty("max")]
    public float Max;

    [JsonProperty("min")]
    public float Min;
}

[Serializable]
public class DogWeight
{
    [JsonProperty("max")]
    public float Max;

    [JsonProperty("min")]
    public float Min;
}

