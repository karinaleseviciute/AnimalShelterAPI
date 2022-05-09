namespace AnimalShelterAPI.AnimalDomain.SearchParams
{
    public class AnimalSearchParams
    {
        public bool male { get; set; }
        public bool female { get; set; }
        public bool lost { get; set; }
        public bool found { get; set; }
        public bool forAdoption { get; set; }
        public bool dogs { get; set; }
        public bool cats { get; set; }
        public bool rodents { get; set; }
        public bool birds { get; set; }
        public bool fish { get; set; }
        public bool other { get; set; }
        public bool young { get; set; }
        public bool adult { get; set; }
        public bool senior { get; set; }
        public string city { get; set; }

    }
}
