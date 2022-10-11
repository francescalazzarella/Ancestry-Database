using Catalog2.Api.Dtos;
using Catalog2.Api.Entities;

namespace Catalog2.Api
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                DOB = item.DOB,
                BirthPlace = item.BirthPlace,
                BirthAnnotation = item.BirthAnnotation,
                DeathDate = item.DeathDate,
                DeathPlace = item.DeathPlace,
                CauseOfDeath = item.CauseOfDeath,
                DeathAnnotation = item.DeathAnnotation,
                CreatedDate = item.CreatedDate
            };
        }
    }
}