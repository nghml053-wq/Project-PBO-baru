using System;

namespace Project_PBO_baru.Models
{
    // Simple reservation model with encapsulation
    public class Reservation
    {
        public int Id { get; internal set; }
        public DateTime CheckIn { get; internal set; }
        public DateTime CheckOut { get; internal set; }
        public decimal Price { get; internal set; }
        public string Status { get; internal set; }
        public int RoomId { get; internal set; }
        public string RoomName { get; internal set; }
        public string RoomStatus { get; internal set; }
        public string Username { get; internal set; }
        public int UserId { get; internal set; }

        // Abstraction: expose nights count
        public int Nights => (int)(CheckOut - CheckIn).TotalDays;

        // Encapsulation: factory for creating Reservation objects
        internal static Reservation Create(int id, DateTime ci, DateTime co, decimal price, string status, int roomId, string roomName, int userId, string username = "", string roomStatus = "")
        {
            return new Reservation
            {
                Id = id,
                CheckIn = ci,
                CheckOut = co,
                Price = price,
                Status = status,
                RoomId = roomId,
                RoomName = roomName,
                UserId = userId
                ,Username = username
                ,RoomStatus = roomStatus
            };
        }
    }
}
