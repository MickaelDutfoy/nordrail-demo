import { useEffect, useState } from "react";
import type { Booking } from "../types";
import LoadingPanel from "../components/LoadingPanel";

function BookingsPage({ isDatabaseLoading }: { isDatabaseLoading: boolean }) {
  const [bookings, setBookings] = useState<Booking[]>([]);
  const [deleteMessage, setDeleteMessage] = useState("");

  const loadBookings = async () => {
    const response = await fetch(
      `${import.meta.env.VITE_API_URL}/api/bookings`,
    );

    if (!response.ok) {
      throw new Error("Failed to load bookings");
    }

    const bookings = await response.json();

    setBookings(bookings);
  };

  useEffect(() => {
    loadBookings();
  }, []);

  const deleteBooking = async (bookingId: number) => {
    const response = await fetch(
      `${import.meta.env.VITE_API_URL}/api/bookings/${bookingId}`,
      {
        method: "DELETE",
      },
    );

    if (!response.ok) {
      setDeleteMessage("Failed to delete booking");
      throw new Error("Failed to delete booking");
    }

    setBookings((currentBookings) =>
      currentBookings.filter((booking) => booking.id !== bookingId),
    );

    setDeleteMessage("Booking deleted.");
  };

  if (isDatabaseLoading) {
    return (
      <section>
        <h1>Bookings</h1>
        <LoadingPanel />
      </section>
    );
  }

  return (
    <section>
      <h1>Bookings</h1>

      {bookings.length === 0 && <p>No bookings yet.</p>}

      <div className="trip-list">
        {bookings.map((booking) => (
          <div key={booking.id} className="trip-card">
            <div className="journey-summary">
              Booking #{booking.id} • {booking.totalDuration} •{" "}
              {booking.totalPrice} NOK
            </div>

            {booking.segments
              .toSorted((a, b) =>
                a.departureTime.localeCompare(b.departureTime),
              )
              .map((segment) => (
                <div key={segment.id} className="trip">
                  <div className="trip-route">
                    {segment.fromCity.name} → {segment.toCity.name}
                  </div>

                  <div className="trip-details">
                    {segment.departureTime} - {segment.arrivalTime}
                  </div>
                </div>
              ))}

            <button
              onClick={() => deleteBooking(booking.id)}
              className="book-button"
            >
              Cancel booking
            </button>
          </div>
        ))}
      </div>

      {deleteMessage && (
        <div className="overlay" onClick={() => setDeleteMessage("")}>
          <div
            className="modal-message"
            onClick={(event) => event.stopPropagation()}
          >
            <p>{deleteMessage}</p>
            <button onClick={() => setDeleteMessage("")}>
              🚂 See you soon on NordRail 🚂
            </button>
          </div>
        </div>
      )}
    </section>
  );
}

export default BookingsPage;
