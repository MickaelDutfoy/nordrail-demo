import { Link, Outlet } from "react-router-dom";

function Layout() {
  return (
    <div>
      <header className="app-header">
        <span className="logo">NordRail</span>

        <nav>
          <Link to="/">Search</Link>
          <Link to="/bookings">Bookings</Link>
        </nav>
      </header>

      <main>
        <Outlet />
      </main>
    </div>
  );
}

export default Layout;