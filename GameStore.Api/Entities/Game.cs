using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Entities;

public class Game
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(20)]
    public required string Genre { get; set; }


    [Range(1, 100)]
    public required decimal Price { get; set; }
    public required DateTime ReleaseDate { get; set; }

    [Url]
    [StringLength(100)]
    public required string ImageURI { get; set; }
}