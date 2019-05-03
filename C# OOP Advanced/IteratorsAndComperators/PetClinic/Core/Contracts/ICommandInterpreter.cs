namespace PetClinic.Core.Contracts
{
    using PetClinic.Contracts;


    public interface ICommandInterpreter
    {
        void CreatePet(string name, int age, string kind);

        void CreateClinic(string name, int rooms);

        bool HasEmptyRooms(string clinicName);

        string PrintRoom(string clinicName, int room);

        string PrintAll(string clinicName);

        bool RealesePet(string clinciName);

        bool AddPetToClinic(string petName, string clinicName);

        IPet GetConcretePet(string petName);

        IClinic GetConcreteClinic(string clinicName);
    }
}
