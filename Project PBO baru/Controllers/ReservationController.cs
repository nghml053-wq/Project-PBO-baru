using System;
using Project_PBO_baru.Services;
using Project_PBO_baru.Models;

namespace Project_PBO_baru.Controllers
{
    // Simple controller to mediate between Views (Forms) and ReservationService (Model)
    public class ReservationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ReservationController
    {
        public ReservationResult CreateReservationByRoomNumber(int userId, string roomNumber, DateTime checkin, DateTime checkout, int jumlahTamu, int metodeId)
        {
            if (!UserSession.IsAuthenticated)
            {
                return new ReservationResult { Success = false, Message = "User not authenticated" };
            }

            if (string.IsNullOrWhiteSpace(roomNumber))
                return new ReservationResult { Success = false, Message = "Invalid room identifier" };

            if (checkout <= checkin)
                return new ReservationResult { Success = false, Message = "Tanggal checkout harus setelah checkin" };

            try
            {
                // map room name/number to id
                var roomId = ReservationService.GetRoomIdByNumber(roomNumber);
                if (roomId == null)
                    return new ReservationResult { Success = false, Message = "Kamar tidak ditemukan" };

                // check availability
                if (!ReservationService.IsRoomAvailable(roomId.Value, checkin, checkout))
                    return new ReservationResult { Success = false, Message = "Kamar tidak tersedia untuk tanggal yang dipilih" };

                bool ok = ReservationService.CreateReservation(userId, roomId.Value, checkin, checkout, jumlahTamu, metodeId);
                if (ok)
                    return new ReservationResult { Success = true, Message = "Reservasi berhasil" };
                else
                    return new ReservationResult { Success = false, Message = "Reservasi gagal. Periksa log untuk detail." };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReservationController error: " + ex);
                return new ReservationResult { Success = false, Message = "Reservasi gagal: " + ex.Message };
            }
        }
    }
}
