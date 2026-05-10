import { useState } from "react";
import type { Journey } from "../types";

function JourneyCards({ journeys }: { journeys: Journey[] }) {
  const [bookingMessage, setBookingMessage] = useState("");

  const bookJourney = async (journey: Journey) => {
    const tripIds = journey.segments.map((segment) => segment.id);

    const response = await fetch("${import.meta.env.VITE_API_URL}/api/bookings", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        tripIds,
      }),
    });

    if (!response.ok) {
      setBookingMessage("Failed to create booking");
      throw new Error("Failed to create booking");
    }

    const booking = await response.json();

    setBookingMessage("Journey booked successfully.");

    console.log("Booking created:", booking);
  };

  return (
    <>
      {journeys.map((journey) => (
        <div key={journey.id} className="trip-card">
          {journey.segments.map((segment) => (
            <div key={segment.id} className="trip">
              <div className="trip-route">
                {segment.fromCity.name} → {segment.toCity.name}
              </div>

              <div className="trip-details">
                {segment.departureTime} - {segment.arrivalTime}
              </div>

              <div className="trip-details">{segment.price} NOK</div>
            </div>
          ))}

          <hr />

          <div className="journey-summary">
            {journey.segmentCount} segment
            {journey.segmentCount > 1 ? "s" : ""} • {journey.totalDuration} •{" "}
            {journey.totalPrice} NOK
          </div>

          <button onClick={() => bookJourney(journey)} className="book-button">
            Book this journey
          </button>
        </div>
      ))}

      {bookingMessage && (
        <div className="overlay" onClick={() => setBookingMessage("")}>
          <div
            className="modal-message"
            onClick={(event) => event.stopPropagation()}
          ><p>
            {bookingMessage}
          </p>
          <button onClick={() => setBookingMessage("")}>🚂 Hurray 🚂</button>
          </div>
        </div>
      )}
    </>
  );
}

export default JourneyCards;
