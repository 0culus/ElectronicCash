using System;

namespace ElectronicCash
{
    public struct ActorName
    {
        private readonly string _firstName;
        private readonly string _middleName;
        private readonly string _lastName;
        private readonly string _title;
        private readonly string _entityName;

        public ActorName(string firstName, string middleName, string lastName, string title)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("First name must not be empty");
            }
            if (string.IsNullOrEmpty(middleName))
            {
                throw new ArgumentException("Middle name must not be empty");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("Last name must not be empty");
            }

            _firstName = firstName;
            _middleName = middleName;
            _lastName = lastName;
            _title = title;
            _entityName = null;
        }

        public ActorName(string entityName)
        {
            if (string.IsNullOrEmpty(entityName))
            {
                throw new ArgumentException("Entity name must be provided");
            }

            _firstName = null;
            _middleName = null;
            _lastName = null;
            _title = null;
            _entityName = entityName;
        }

        public string FirstName => _firstName;
        public string MiddleName => _middleName;
        public string LastName => _lastName;
        public string Title => _title;
        public string EntityName => _entityName;
    }
}
