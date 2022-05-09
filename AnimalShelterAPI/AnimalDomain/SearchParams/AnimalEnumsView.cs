using static AnimalShelterAPI.AnimalDomain.Models.Animal;

namespace AnimalShelterAPI.AnimalDomain.SearchParams
{
    public class AnimalEnumsView
    {
        public AnimalGender? male { get; set; }
        public AnimalGender? female { get; set; }
        public AnimalStatus? lost { get; set; }
        public AnimalStatus? found { get; set; }
        public AnimalStatus? forAdoption { get; set; }
        public AnimalType? dogs { get; set; }
        public AnimalType? cats { get; set; }
        public AnimalType? rodents { get; set; }
        public AnimalType? birds { get; set; }
        public AnimalType? fish { get; set; }
        public AnimalType? other { get; set; }
        public AgeRange? young { get; set; }
        public AgeRange? adult { get; set; }
        public AgeRange? senior { get; set; }
        public string? city { get; set; }


        public static AnimalEnumsView ToAnimalEnumsView(AnimalSearchParams model)
        {
            if (model == null)
                return null;

            var vm = new AnimalEnumsView()
            {
                male = model.male == true ? AnimalGender.Male : null,
                female = model.female == true ? AnimalGender.Female : null,
                lost = model.lost == true ? AnimalStatus.Lost : null,
                found = model.found == true ? AnimalStatus.Found : null,
                forAdoption = model.forAdoption == true ? AnimalStatus.ForAdoption : null,
                dogs = model.dogs == true ? AnimalType.Dog : null,
                cats = model.cats == true ? AnimalType.Cat : null,
                rodents = model.rodents == true ? AnimalType.Rodent : null,
                birds = model.birds == true ? AnimalType.Bird : null,
                fish = model.fish == true ? AnimalType.Fish : null,
                other = model.other == true ? AnimalType.Other : null,
                young = model.young == true ? AgeRange.Puppy : null,
                adult = model.adult == true ? AgeRange.Adult : null,
                senior = model.senior == true ? AgeRange.Senior : null,
                city = model.city

            };

            return vm;
        }
    }
}
