import { useEffect, useState } from "react";
import type { City, Journey } from "../types";
import JourneyCards from "../components/JourneyCard";
import LoadingPanel from "../components/LoadingPanel";

function SearchPage({
  cities,
  isDatabaseLoading,
}: {
  cities: City[];
  isDatabaseLoading: boolean;
}) {
  const [fromCity, setFromCity] = useState("");
  const [toCity, setToCity] = useState("");

  const [journeys, setJourneys] = useState<Journey[]>([]);

  const [errorMessage, setErrorMessage] = useState("");

  useEffect(() => {
    if (cities.length >= 2) {
      setFromCity(cities[0].name);
      setToCity(cities[1].name);
    }
  }, [cities]);

  const searchTrips = async () => {
    const response = await fetch(
      `${import.meta.env.VITE_API_URL}/api/journeys?from=${fromCity}&to=${toCity}`,
    );

    const journeys = await response.json();

    setJourneys(journeys);

    if (journeys.length === 0) {
      setErrorMessage("No trips found between those locations.");
    }
  };

  return (
    <section>
      <h1>Search</h1>
      {isDatabaseLoading ? (
        <LoadingPanel />
      ) : (
        <div className="search-form">
          <div className="field">
            <label htmlFor="from-city">From</label>

            <select
              id="from-city"
              value={fromCity}
              onChange={(event) => setFromCity(event.target.value)}
            >
              {cities.map((city) => (
                <option
                  key={city.id}
                  value={city.name}
                  disabled={toCity === city.name}
                >
                  {city.name}
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
                <option
                  key={city.id}
                  value={city.name}
                  disabled={fromCity === city.name}
                >
                  {city.name}
                </option>
              ))}
            </select>
          </div>

          <button onClick={searchTrips}>Search</button>
        </div>
      )}

      {!errorMessage ? (
        <div className="trip-list">
          <JourneyCards journeys={journeys} />
        </div>
      ) : (
        <div className="overlay" onClick={() => setErrorMessage("")}>
          <div
            className="modal-message"
            onClick={(event) => event.stopPropagation()}
          >
            <p>{errorMessage}</p>
            <button onClick={() => setErrorMessage("")}>🚂 Oops 🚂</button>
          </div>
        </div>
      )}
    </section>
  );
}

export default SearchPage;
