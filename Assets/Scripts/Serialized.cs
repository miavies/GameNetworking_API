using System;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using TMPro;

public class Serialized : MonoBehaviour
{
    [SerializeField] private int pageNumber = 1;
    [SerializeField] private int maxPages = 29;
    [SerializeField] private TextMeshProUGUI pageStatus;
    [SerializeField] private GameObject container;
    [SerializeField] private TextMeshProUGUI content;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        pageNumber = 1;
        pageStatus.text = $"{pageNumber}/{maxPages}";
        container.transform.position = new Vector3(container.transform.position.x, 0, container.transform.position.z);
        DisplayDogInformation();
    }

    void DisplayDogInformation()
    {
        StartCoroutine(APIManager.Get<DogBreedAPI>(pageNumber + APIManager.CONT_URL,
            (data) => 
            { 
                var sb = new StringBuilder();
                foreach(var breed in data.Data)
                {
                    //Attributes
                    sb.AppendLine($"Name: {breed.Attributes.Name}");
                    sb.AppendLine("");
                    sb.AppendLine("Description:");
                    sb.AppendLine(breed.Attributes.Description);

                    //Life
                    sb.AppendLine("");
                    sb.AppendLine("Life:");
                        sb.AppendLine($"     Max: {breed.Attributes.Life.Max}");
                        sb.AppendLine($"     Min: {breed.Attributes.Life.Min}");

                    //Male Weight
                    sb.AppendLine("");
                    sb.AppendLine("Male Weight:");
                        sb.AppendLine($"     Max: {breed.Attributes.MaleWeight.Max}");
                        sb.AppendLine($"     Min: {breed.Attributes.MaleWeight.Min}");

                    //Female Weight
                    sb.AppendLine("");
                    sb.AppendLine("Female Weight:");
                        sb.AppendLine($"     Max: {breed.Attributes.FemaleWeight.Max}");
                        sb.AppendLine($"     Min: {breed.Attributes.FemaleWeight.Min}");

                    sb.AppendLine("");
                    sb.AppendLine($"Hypoallergenic: {breed.Attributes.Hypoallergenic}");
                    sb.AppendLine("");
                    sb.AppendLine("");
                    sb.AppendLine("");
                }
                content.text = sb.ToString();
                pageStatus.text = $"{pageNumber}/{maxPages}";
                container.transform.position = new Vector3(container.transform.position.x, 0, container.transform.position.z);

                Debug.Log(sb.ToString());
            },
            (error) => { }));
    }

    public void NextPage()
    {
        pageNumber++;
        if (pageNumber >= maxPages)
        {
            pageNumber = maxPages;
        }
        DisplayDogInformation();
    }

    public void PreviousPage()
    {
        pageNumber--;
        if (pageNumber <= 0)
        {
            pageNumber = 1;
        }
        DisplayDogInformation();
    }
}

