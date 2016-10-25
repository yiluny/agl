using System.ComponentModel.DataAnnotations;

namespace AGL.Core.Models
{
    public enum AnimalType
    {
        [Display(Name = "Cat")]
        cat,
        [Display(Name = "Dog")]
        dog,
        [Display(Name = "Fish")]
        fish
    }
}