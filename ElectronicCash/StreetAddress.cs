namespace ElectronicCash
{
    /// <summary>
    /// Store the components of the customer's or entity's street address
    /// </summary>
    public struct StreetAddress
    {
        private readonly string _road;
        private readonly string _cityState;
        private readonly string _zipCode;
        private readonly string _apartmentNumber;

        public StreetAddress(string road, string cityState, string zipCode) 
            : this(road, cityState, zipCode, null)
        {
            
        }

        public StreetAddress(string road, string cityState, string zipCode, string apartmentNumber)
        {
            _apartmentNumber = apartmentNumber;
            _cityState = cityState;
            _road = road;
            _zipCode = zipCode;
        }

        public string Road => _road;
        public string CityState => _cityState;
        public string ZipCode => _zipCode;
        public string ApartmentNumber => _apartmentNumber;
    }
}
