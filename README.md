# NordRail

NordRail is a simple railway booking application built as a technical showcase project.

It was created to explore the ASP.NET Core ecosystem while reusing a familiar React and TypeScript frontend.

The application is fully deployed and functional.

## Overview

NordRail allows users to:

- search for train journeys between Norwegian cities
- view trip details, including segments, duration, and total price
- create bookings
- view existing bookings
- cancel bookings

The project is intended as a compact full-stack example rather than a production-ready booking platform.

## Tech stack

### Frontend

- React
- TypeScript
- Vite
- React Router

### Backend

- ASP.NET Core Web API
- C#
- Entity Framework Core

### Infrastructure

- Azure SQL Database
- Azure App Service
- Azure Static Web Apps
- GitHub Actions (deployment)

## Architecture overview

NordRail is split into two separate applications:

- a React frontend responsible for the user interface and API calls
- an ASP.NET Core backend exposing REST endpoints

The backend uses Entity Framework Core to access a relational SQL database hosted on Azure.

The frontend communicates with the backend through standard `fetch()` requests.

## Database model

The application relies on four main entities:

- City
- Trip
- Journey
- Booking

A trip references a departure city and an arrival city.
A journey consists of one or two consecutive trips.
A booking references a selected journey.

## User interface

The interface includes:

- a trip search form
- a list of available journeys
- booking confirmation dialogs
- a booking management page
- cancellation confirmation dialogs

The design is intentionally simple and focused on clarity.

## Live demo

Frontend:
https://gray-pebble-0725c0803.7.azurestaticapps.net

Backend API:
https://nordrail-backend-hzfxbdb3fsbba6cj.swedencentral-01.azurewebsites.net

## Purpose

This project was built as a practical introduction to:

- C#
- ASP.NET Core
- Entity Framework Core
- Azure deployment

It serves as a concise full-stack showcase combining React and .NET technologies.