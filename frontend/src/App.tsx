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
    const loadCities = async () => {
      try {
        const response = await fetch(
          `${import.meta.env.VITE_API_URL}/api/cities`,
        );

        if (!response.ok) {
          throw new Error("Failed to load cities");
        }

        const data = await response.json();

        setCities(data);
      } catch (error) {
        console.error("Unable to load cities:", error);
      } finally {
        setIsDatabaseLoading(false);
      }
    };

    loadCities();
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
