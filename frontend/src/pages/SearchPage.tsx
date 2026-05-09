import { useEffect, useState } from "react";
import type { Journey } from "../types/journey";

function SearchPage() {
  const [cities, setCities] = useState<string[]>([]);

  const [fromCity, setFromCity] = useState("");
  const [toCity, setToCity] = useState("");

  const [journeys, setJourneys] = useState<Journey[]>([]);

  const [bookingMessage, setBookingMessage] = useState("");

  useEffect(() => {
    const loadCities = async () => {
      const response = await fetch("http://localhost:5283/api/cities");

      const cities = await response.json();

      setCities(cities);

      if (cities.length >= 2) {
        setFromCity(cities[0]);
        setToCity(cities[1]);
      }
    };

    loadCities();
  }, []);

  const searchTrips = async () => {
    const response = await fetch(
      `http://localhost:5283/api/journeys?from=${fromCity}&to=${toCity}`,
    );

    const journeys = await response.json();

    setJourneys(journeys);
  };

  const bookJourney = async (journey: Journey) => {
    const tripIds = journey.segments.map((segment) => segment.id);

    const response = await fetch("http://localhost:5283/api/bookings", {
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
    <section>
      <h1>Search</h1>
      <div className="search-form">
        <div className="field">
          <label htmlFor="from-city">From</label>

          <select
            id="from-city"
            value={fromCity}
            onChange={(event) => setFromCity(event.target.value)}
          >
            {cities.map((city) => (
              <option key={city} value={city}>
                {city}
              </option>
            ))}
          </select>
        </div>

        <div className="field">
          <label htmlFor="to-city">To</label>

          <select
            id="to-city"
            value={toCity}
            onChange={(event) => setToCity(event.target.value)}
          >
            {cities.map((city) => (
              <option key={city} value={city}>
                {city}
              </option>
            ))}
          </select>
        </div>

        <button onClick={searchTrips}>Search</button>
      </div>

      <div className="trip-list">
        {journeys.map((journey) => (
          <div key={journey.id} className="trip-card">
            {journey.segments.map((segment) => (
              <div key={segment.id} className="trip">
                <div className="trip-route">
                  {segment.from} → {segment.to}
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

            <button onClick={() => bookJourney(journey)}>
              Book this journey
            </button>
          </div>
        ))}
        {bookingMessage && <p className="success-message">{bookingMessage}</p>}
      </div>
    </section>
  );
}

export default SearchPage;
