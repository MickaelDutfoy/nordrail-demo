export type Trip = {
  id: number;
  from: string;
  to: string;
  departureTime: string;
  arrivalTime: string;
  price: number;
};

export type Journey = {
  id: string;
  segments: Trip[];
  totalPrice: number;
  totalDuration: string;
  segmentCount: number;
};

export type Booking = {
  id: number;
  segments: Trip[];
  totalPrice: number;
  totalDuration: string;
  createdAt: string;
};