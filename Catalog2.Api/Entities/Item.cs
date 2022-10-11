using System;
using System.Collections.Generic;
using Catalog2.Api.Entities;

namespace Catalog2.Api.Entities
{
    public record Item
        {
          public Guid Id {get; init;}
          public string Name {get; init;}
          public string DOB {get; init;}
          public string BirthPlace {get; init;}
          public string BirthAnnotation {get; init;}
          public string DeathDate {get; init;}
          public string DeathPlace {get; init;}
          public string CauseOfDeath {get; init;}
          public string DeathAnnotation{get; init;}
          public DateTimeOffset CreatedDate {get; init;}
        }
}