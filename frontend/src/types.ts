export type City = {
  id: number;
  name: string;
}

export type Trip = {
  id: number;
  fromCity: City;
  toCity: City;
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