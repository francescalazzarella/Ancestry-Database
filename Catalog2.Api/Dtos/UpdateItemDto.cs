using System.ComponentModel.DataAnnotations;

namespace Catalog2.Api.Dtos
{
    public record UpdateItemDto
    {
          public string Name {get; init;}
          public string DOB {get; init;}
          public string  BirthPlace {get; init;}
          public string BirthAnnotation {get; init;}
          public string  DeathDate {get; init;}
          public string DeathPlace {get; init;}
          public string CauseOfDeath {get; init;}
          public string DeathAnnotation{get; init;}

    }
}