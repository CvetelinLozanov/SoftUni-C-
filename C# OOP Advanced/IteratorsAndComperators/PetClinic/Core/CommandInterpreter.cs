namespace PetClinic.Core
{
    using PetClinic.Contracts;
    using PetClinic.Core.Contracts;
    using PetClinic.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IList<IPet> pets;
        private IList<IClinic> clinics;

        public CommandInterpreter()
        {
            pets = new List<IPet>();
            clinics = new List<IClinic>();
        }

        public bool AddPetToClinic(string petName, string clinicName)
        {
            IPet pet = GetConcretePet(petName);
            IClinic clinic = GetConcreteClinic(clinicName);
            return clinic.AddPet(pet);
        }

        public void CreateClinic(string name, int rooms)
        {
            IClinic clinic = new Clinic(name, rooms);
            this.clinics.Add(clinic);
        }

        public void CreatePet(string name, int age, string kind)
        {
            IPet pet = new Pet(name, age, kind);
            this.pets.Add(pet);
        }

        public IClinic GetConcreteClinic(string clinicName)
        {
            IClinic clinic = this.clinics.FirstOrDefault(x => x.Name == clinicName);
            return clinic;
        }

        public IPet GetConcretePet(string petName)
        {
            IPet pet = this.pets.FirstOrDefault(p => p.Name == petName);
            return pet;
        }

        public bool HasEmptyRooms(string clinicName)
        {
            IClinic clinic = this.GetConcreteClinic(clinicName);
            return clinic.HasEmptyRooms();
        }

        public string PrintRoom(string clinicName, int room)
        {
            IClinic clinic = this.GetConcreteClinic(clinicName);
            return clinic.GetRoomState(room);
        }

        public string PrintAll(string clinicName)
        {
            IClinic clinic = this.GetConcreteClinic(clinicName);   
            return clinic.GetAllRoomState();
        }

        public bool RealesePet(string clinicName)
        {
            IClinic clinic = this.GetConcreteClinic(clinicName);
            return clinic.ReleasePet();
        }
    }
}
