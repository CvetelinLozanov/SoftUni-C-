namespace PetClinic.Models
{
    using PetClinic.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class Clinic : IClinic
    {
        private readonly int numberOfRooms;

        private string name;
        private IPet[] roomsContent;

        public Clinic(string name, int roomsCount)
        {
            this.Name = name;
            this.ValidateRoomsCount(roomsCount);
            this.roomsContent = new IPet[roomsCount];
            this.numberOfRooms = roomsCount / 2;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public bool HasEmptyRooms() => roomsContent.Any(x => x == null);

        public bool AddPet(IPet pet)
        {
            for (int i = 0; i <= numberOfRooms; i++)
            {
                if (roomsContent[numberOfRooms - i] == null)
                {
                    this.roomsContent[numberOfRooms - i] = pet;
                    return true;
                }
                if (roomsContent[numberOfRooms + i] == null)
                {
                    this.roomsContent[numberOfRooms + i] = pet;
                    return true;
                }
            }
            return false;
        }

        public bool ReleasePet()
        {
            for (int i = numberOfRooms; i < this.roomsContent.Length; i++)
            {
                if (roomsContent[i] != null)
                {
                    roomsContent[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < numberOfRooms; i++)
            {
                if (roomsContent[i] != null)
                {
                    roomsContent[i] = null;
                    return true;
                }
            }

            return false;
        }

        public string GetRoomState(int number)
        {
            number--;

            if (number < 0 || number > this.roomsContent.Length - 1)
            {
                throw new InvalidOperationException("Invalid Operation");
            }
            string result = (this.roomsContent[number] == null)
                ? "Room empty"
                : this.roomsContent[number].ToString();
            return result;
        }

        public string GetAllRoomState()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var room in roomsContent)
            {
                if (room == null)
                {
                    sb.AppendLine("Room Empty");
                }
                else
                {
                    sb.AppendLine(room.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        private void ValidateRoomsCount(int roomsCount)
        {
            if (roomsCount % 2 == 0 || roomsCount < 1 || roomsCount > 101)
            {
                throw new InvalidOperationException("Invalid Operation");
            }
        }       
    }
}
