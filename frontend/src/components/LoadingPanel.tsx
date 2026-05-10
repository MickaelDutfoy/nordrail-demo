function LoadingPanel() {
  return (
    <div className="loading-panel">
      <p className="wait-message">Starting up, please wait... 🚂</p>

      <div className="cold-start-card">
        <div className="cold-start-icon">i</div>

        <div>
          <p className="cold-start-title">Database cold start</p>
          <p>
            The database is waking up after being idle and may take up to a
            minute to respond.
          </p>
          <p>This only happens after periods of inactivity on the free plan.</p>
        </div>
      </div>

      <p className="coffee-message">
        ☕ Offer yourself a coffee while waiting!
      </p>
    </div>
  );
}

export default LoadingPanel;
