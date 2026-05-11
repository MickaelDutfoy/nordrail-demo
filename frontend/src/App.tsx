import { BrowserRouter, Route, Routes } from "react-router-dom";
import Layout from "./components/Layout";
import SearchPage from "./pages/SearchPage";
import BookingsPage from "./pages/BookingsPage";
import { useEffect, useState } from "react";
import type { City } from "./types";

function App() {
  const [cities, setCities] = useState<City[]>([]);
  const [isDatabaseLoading, setIsDatabaseLoading] = useState(true);

  useEffect(() => {
    let isCancelled = false;

    const loadCities = async () => {
      try {
        const response = await fetch(
          `${import.meta.env.VITE_API_URL}/api/cities`,
        );

        if (!response.ok) {
          throw new Error("Failed to load cities");
        }

        const data = await response.json();

        if (!Array.isArray(data) || data.length < 2) {
          throw new Error("Invalid cities data");
        }

        if (!isCancelled) {
          setCities(data);
          setIsDatabaseLoading(false);
        }
      } catch (error) {
        console.error("Unable to load cities, retrying...", error);

        // trying to fight against Azure cold start - please ignore :-)
        if (!isCancelled) {
          setTimeout(loadCities, 5000);
        }
      }
    };

    loadCities();

    return () => {
      isCancelled = true;
    };
  }, []);

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route
            index
            element={
              <SearchPage
                cities={cities}
                isDatabaseLoading={isDatabaseLoading}
              />
            }
          />

          <Route
            path="bookings"
            element={<BookingsPage isDatabaseLoading={isDatabaseLoading} />}
          />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
