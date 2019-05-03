namespace PetClinic.Contracts
{
    public interface IClinic
    {
        string Name { get; }

        bool HasEmptyRooms();

        bool AddPet(IPet pet);

        bool ReleasePet();

        string GetRoomState(int number);

        string GetAllRoomState();
    }
}
