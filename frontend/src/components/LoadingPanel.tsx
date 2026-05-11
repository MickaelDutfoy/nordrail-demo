function LoadingPanel() {
  return (
    <div className="loading-panel">
      <p className="wait-message">Starting up, please wait... 🚂</p>

      <div className="cold-start-card">
        <div className="cold-start-icon">i</div>

        <div>
          <p className="cold-start-title">Service startup</p>
          <p>
            The backend and database are hosted on free-tier Azure services and
            may take up to a minute to wake up after inactivity.
          </p>
          <p>
            The app should continue automatically once the service is ready.
          </p>
        </div>
      </div>

      <p className="coffee-message">
        ☕ Offer yourself a coffee while waiting!
      </p>
    </div>
  );
}

export default LoadingPanel;
