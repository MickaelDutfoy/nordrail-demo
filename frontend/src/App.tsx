import { useEffect, useState } from "react";

type Trip = {
  id: number;
  from: string;
  to: string;
  departureTime: string;
  price: number;
};

function App() {
  const [cities, setCities] = useState<string[]>([]);

  const [fromCity, setFromCity] = useState("");
  const [toCity, setToCity] = useState("");

  const [trips, setTrips] = useState<Trip[]>([]);

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
      `http://localhost:5283/api/trips?from=${fromCity}&to=${toCity}`,
    );

    const trips = await response.json();

    setTrips(trips);
  };

  return (
    <main>
      <h1>NordRail</h1>

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
        {trips.map((trip) => (
          <div key={trip.id} className="trip-card">
            <div className="trip-route">
              {trip.from} → {trip.to}
            </div>

            <div className="trip-details">Departure: {trip.departureTime}</div>

            <div className="trip-details">Price: {trip.price} NOK</div>
          </div>
        ))}
      </div>
    </main>
  );
}

export default App;
